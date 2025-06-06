using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Networks.DTOs;
using WatchListMovies.Query.Networks.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class NetworkController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public NetworkController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetNetworksByFilter")]
        public async Task<ApiResult<NetworkFilterResult>> GetNetworksByFilter([FromQuery] NetworkFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetNetworksByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
