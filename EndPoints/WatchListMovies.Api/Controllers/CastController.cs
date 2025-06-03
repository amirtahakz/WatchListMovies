using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Application.Services.Cast.MakeRecommended;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Cast.DTOs;
using WatchListMovies.Query.Cast.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class CastController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CastController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetCastsByFilter")]
        public async Task<ApiResult<CastFilterResult>> GetCastsByFilter([FromQuery] CastFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetCastsByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [HttpPut("MakeRecommendedACastByApiModelId")]
        public async Task<ApiResult<bool>> MakeRecommendedACastByApiModelId([FromQuery] long apiModelId)
        {
            var result = await _mediator.Send(new MakeRecommendedACastByApiModelIdCommand() { ApiModelId = apiModelId });
            return CommandResult(result);
        }
    }
}
