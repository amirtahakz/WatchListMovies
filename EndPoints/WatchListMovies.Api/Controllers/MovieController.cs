using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.Movie;
using WatchListMovies.Application.Services.Movie.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class MovieController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public MovieController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetMoviesByFilter")]
        public async Task<ApiResult<MovieFilterResult>> GetMoviesByFilter([FromQuery] MovieFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetMovieByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [Authorize]
        [HttpPost("CreateMovie")]
        public async Task<ApiResult<Guid>> CreateMovie([FromQuery] CreateMovieViewModel viewModel)
        {
            var command = _mapper.Map<CreateMovieCommand>(viewModel);
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }
    }
}
