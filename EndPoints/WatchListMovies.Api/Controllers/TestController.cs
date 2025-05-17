using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using WatchListMovies.Api.ViewModels.List;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.Services.List.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Lists.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        private readonly IMovieApiService _movieApiService;
        private readonly TMDBConfig _config;

        public TestController(IMediator mediator, IMapper mapper, IMovieApiService movieApiService, IOptions<TMDBConfig> config)
        {
            _mediator = mediator;
            _mapper = mapper;
            _movieApiService = movieApiService;
            _config = config.Value;
        }

        //[HttpPost("CreateList")]
        //public async Task<ApiResult<Guid>> CreateList([FromQuery] CreateListViewModel viewModel)
        //{
        //    var command = _mapper.Map<CreateListCommand>(viewModel);
        //    command.UserId = User.GetUserId();
        //    var result = await _mediator.Send(command);
        //    return CommandResult(result);
        //}

        [HttpGet]
        public async Task<IActionResult> GetListByFilter()
        {
            var t = _config.BaseAddress;
            var result = await _movieApiService.GetPopularMovies();
            return Ok(result);
        }
    }
}
