using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Seasons.DTOs;
using WatchListMovies.Query.Seasons.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class SeasonController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public SeasonController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetSeasonsByFilter")]
        public async Task<ApiResult<SeasonFilterResult>> GetSeasonsByFilter([FromQuery] SeasonFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetSeasonsByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
