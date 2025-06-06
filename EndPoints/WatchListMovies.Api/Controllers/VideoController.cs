using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Videos.DTOs;
using WatchListMovies.Query.Videos.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class VideoController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public VideoController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetVideosByFilter")]
        public async Task<ApiResult<VideoFilterResult>> GetVideosByFilter([FromQuery] VideoFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetVideosByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
