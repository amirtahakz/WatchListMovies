using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Genre.DTOs;
using WatchListMovies.Query.Genre.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class GenreController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GenreController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetGenresByFilter")]
        public async Task<ApiResult<GenreFilterResult>> GetGenresByFilter([FromQuery] GenreFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetGenresByFilterQuery(filterParams));
            return QueryResult(result);
        }

    }
}
