using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security;
using WatchListMovies.Api.ViewModels.Users;
using WatchListMovies.Application.Services.Users.ChangePassword;
using WatchListMovies.Application.Services.Users.Create;
using WatchListMovies.Application.Services.Users.Edit;
using WatchListMovies.Common.Application;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Query.Users.DTOs;
using WatchListMovies.Query.Users.GetByFilter;
using WatchListMovies.Query.Users.GetById;

namespace WatchListMovies.Api.Controllers
{
    [Authorize]
    public class UserController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public UserController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetUsers")]
        public async Task<ApiResult<UserFilterResult>> GetUsers([FromQuery] UserFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetUserByFilterQuery(filterParams));
            return QueryResult(result);
        }
        [HttpGet("Current")]
        public async Task<ApiResult<UserDto>> GetCurrentUser()
        {
            var result = await _mediator.Send(new GetUserByIdQuery(User.GetUserId()));
            return QueryResult(result);
        }

        [HttpGet("{userId}")]
        public async Task<ApiResult<UserDto?>> GetById(Guid userId)
        {
            var result = await _mediator.Send(new GetUserByIdQuery(userId));
            return QueryResult(result);
        }

        [HttpPost("CreateUser")]
        public async Task<ApiResult> CreateUser(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }

        [HttpPut("ChangePassword")]
        public async Task<ApiResult> ChangePassword(ChangePasswordViewModel command)
        {
            var changePasswordModel = _mapper.Map<ChangeUserPasswordCommand>(command);
            changePasswordModel.UserId = User.GetUserId();
            var result = await _mediator.Send(command);
            return CommandResult((OperationResult)result);
        }

        [HttpPut("Current")]
        public async Task<ApiResult> EditUser([FromForm] EditUserViewModel command)
        {
            var commandModel = new EditUserCommand()
            {
                UserId = User.GetUserId(),
                Avatar = command.Avatar,
                Email = command.Email,
                Family = command.Family,
                Gender = command.Gender,
                Name = command.Name,
                PhoneNumber = command.PhoneNumber,
            };

            var result = await _mediator.Send(command);
            return CommandResult((OperationResult)result);
        }

        [HttpPut]
        public async Task<ApiResult> Edit([FromForm] EditUserCommand command)
        {
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }
    }
}
