using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Episodes.DTOs;
using WatchListMovies.Query.Episodes.GetByFilter;
using WatchListMovies.Query.Seasons.DTOs;
using WatchListMovies.Query.Seasons.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class EpisodeController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public EpisodeController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetEpisodesByFilter")]
        public async Task<ApiResult<EpisodeFilterResult>> GetEpisodesByFilter([FromQuery] EpisodeFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetEpisodesByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
