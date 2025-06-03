using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Application.Services.Tv.MakeRecommended;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Tvs.DTOs;
using WatchListMovies.Query.Tvs.GetByFilter;
using WatchListMovies.Query.Tvs.GetOnTheAir;
using WatchListMovies.Query.Tvs.GetRecommended;

namespace WatchListMovies.Api.Controllers
{
    public class TvController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TvController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetTvsByFilter")]
        public async Task<ApiResult<TvFilterResult>> GetTvsByFilter([FromQuery] TvFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetTvsByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [HttpPut("MakeRecommendedATvByApiModelId")]
        public async Task<ApiResult<bool>> MakeRecommendedATvByApiModelId([FromQuery] MakeRecommendedATvByApiModelIdCommand model)
        {
            var result = await _mediator.Send(model);
            return CommandResult(result);
        }

        [HttpGet("GetRecommendedTvs")]
        public async Task<ApiResult<List<TvDto>>> GetRecommendedTvs([FromQuery] GetRecommendedTvsQuery model)
        {
            var result = await _mediator.Send(model);
            return QueryResult(result);
        }

        [HttpGet("GetOnTheAirTvs")]
        public async Task<ApiResult<GetOnTheAirTvsResult>> GetOnTheAirTvs([FromQuery] GetOnTheAirTvsParams filterParams)
        {
            var result = await _mediator.Send(new GetOnTheAirTvsQuery(filterParams));
            return QueryResult(result);
        }
    }
}
