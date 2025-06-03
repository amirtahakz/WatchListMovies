using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Application.Services.Movie.MakeRecommended;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetByFilter;
using WatchListMovies.Query.Movies.GetById;
using WatchListMovies.Query.Movies.GetRecommended;
using WatchListMovies.Query.Movies.GetSimilar;
using WatchListMovies.Query.Movies.GetUpcoming;

namespace WatchListMovies.Api.Controllers
{
    public class MovieController : BaseApiController
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
            var result = await _mediator.Send(new GetMoviesByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [HttpGet("GetUpcomingMovies")]
        public async Task<ApiResult<UpcomingMoviesFilterResult>> GetUpcomingMovies([FromQuery] UpcomingMoviesFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetUpcomingMoviesQuery(filterParams));
            return QueryResult(result);
        }

        [HttpGet("GetSimilarMovies")]
        public async Task<ApiResult<List<MovieDto>>> GetSimilarMovies([FromQuery] GetSimilarMoviesQuery filterParams)
        {
            var result = await _mediator.Send(filterParams);
            return QueryResult(result);
        }

        [HttpGet("GetMovieById")]
        public async Task<ApiResult<MovieDto>> GetMovieById([FromQuery] Guid movieId)
        {
            var result = await _mediator.Send(new GetMovieByIdQuery(movieId));
            return QueryResult(result);
        }

        [HttpPut("MakeRecommendedAMovieByImdbId")]
        public async Task<ApiResult<bool>> MakeRecommendedAMovieByImdbId([FromQuery] string imdbId)
        {
            var result = await _mediator.Send(new MakeRecommendedAMovieByImdbIdCommand() { ImdbId = imdbId });
            return CommandResult(result);
        }

        [HttpGet("GetRecommendedMovies")]
        public async Task<ApiResult<List<MovieDto>>> GetRecommendedMovies([FromQuery] int take)
        {
            var result = await _mediator.Send(new GetRecommendedMoviesQuery() { Take = take });
            return QueryResult(result);
        }
    }
}
