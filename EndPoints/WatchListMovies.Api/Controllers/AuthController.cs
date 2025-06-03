using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using UAParser;
using WatchListMovies.Api.Infrastructure.JwtUtil;
using WatchListMovies.Api.ViewModels.Auth;
using WatchListMovies.Common.Application.SecurityUtil;
using WatchListMovies.Common.Application;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Users.DTOs;
using MediatR;
using WatchListMovies.Query.Users.GetByPhoneNumber;
using WatchListMovies.Query.Users.UserTokens.GetByRefreshToken;
using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Query.Users.GetById;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Newtonsoft.Json.Linq;
using WatchListMovies.Query.Users.UserTokens.GetByJwtToken;
using WatchListMovies.Application.Services.Users.RegisterUser;
using WatchListMovies.Application.Services.Users.RemoveToken;
using WatchListMovies.Application.Services.Users.AddToken;

namespace Api.Controllers;

public class AuthController : BaseApiController
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;

    public AuthController(IMediator mediator, IConfiguration configuration)
    {
        _mediator = mediator;
        _configuration = configuration;
    }

    [HttpPost("login")]
    public async Task<ApiResult<LoginResultDto?>> Login(LoginViewModel loginViewModel)
    {
        var user = await _mediator.Send(new GetUserByPhoneNumberQuery(loginViewModel.PhoneNumber));
        if(user == null)
        {
            var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }

        if (Sha256Hasher.IsCompare(user.Password, loginViewModel.Password) == false)
        {
            var result = OperationResult<LoginResultDto>.Error("کاربری با مشخصات وارد شده یافت نشد");
            return CommandResult(result);
        }

        //if (user.IsActive == false)
        //{
        //    var result = OperationResult<LoginResultDto>.Error("حساب کاربری شما غیرفعال است");
        //    return CommandResult(result);
        //}

        var loginResult = await AddTokenAndGenerateJwt(user);
        return CommandResult(loginResult);
    }

    [HttpPost("register")]
    public async Task<ApiResult> Register(RegisterViewModel register)
    {
        var command = new RegisterUserCommand(register.PhoneNumber, register.Password);
        var result = await _mediator.Send(command);
        return CommandResult(result);
    }
    [HttpPost("RefreshToken")]
    public async Task<ApiResult<LoginResultDto?>> RefreshToken(string refreshToken)
    {
        var hashRefreshToken = Sha256Hasher.Hash(refreshToken);
        var result = await _mediator.Send(new GetUserTokenByRefreshTokenQuery(hashRefreshToken));

        if (result == null)
            return CommandResult(OperationResult<LoginResultDto?>.NotFound());

        if (result.TokenExpireDate > DateTime.Now)
            return CommandResult(OperationResult<LoginResultDto>.Error("توکن هنوز منقضی نشده است"));


        if (result.RefreshTokenExpireDate < DateTime.Now)
            return CommandResult(OperationResult<LoginResultDto>.Error("زمان رفرش توکن به پایان رسیده است"));


        var user = await _mediator.Send(new GetUserByIdQuery(result.UserId));
        var removeTokenResult = await _mediator.Send(new RemoveUserTokenCommand(result.UserId, result.Id));
        var loginResult = await AddTokenAndGenerateJwt(user);
        return CommandResult(loginResult);
    }

    [Authorize]
    [HttpDelete("logout")]
    public async Task<ApiResult> Logout()
    {
        var token = await HttpContext.GetTokenAsync("access_token");
        var hashJwtToken = Sha256Hasher.Hash(token);
        var result = await _mediator.Send(new GetUserTokenByJwtTokenQuery(hashJwtToken));
        if (result == null)
            return CommandResult(OperationResult.NotFound());

        var removeTokenResult = await _mediator.Send(new RemoveUserTokenCommand(result.UserId, result.Id));
        return CommandResult(OperationResult.Success());
    }

    private async Task<OperationResult<LoginResultDto?>> AddTokenAndGenerateJwt(UserDto user)
    {
        var uaParser = Parser.GetDefault();
        var header = HttpContext.Request.Headers["user-agent"].ToString();
        var device = "windows";
        if (header != null)
        {
            var info = uaParser.Parse(header);
            device = $"{info.Device.Family}/{info.OS.Family} {info.OS.Major}.{info.OS.Minor} - {info.UA.Family}";
        }

        var token = JwtTokenBuilder.BuildToken(user, _configuration);
        var refreshToken = Guid.NewGuid().ToString();

        var hashJwt = Sha256Hasher.Hash(token);
        var hashRefreshToken = Sha256Hasher.Hash(refreshToken);

        var tokenResult = await _mediator.Send(new AddUserTokenCommand(user.Id, hashJwt, hashRefreshToken, DateTime.Now.AddDays(7), DateTime.Now.AddDays(8), device));
        if (tokenResult.Status != OperationResultStatus.Success)
            return OperationResult<LoginResultDto?>.Error();

        return OperationResult<LoginResultDto?>.Success(new LoginResultDto()
        {
            Token = token,
            RefreshToken = refreshToken
        });
    }
}