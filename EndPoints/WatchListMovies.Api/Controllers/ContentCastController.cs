using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.ContentCasts.GetByFilter;
using WatchListMovies.Query.ContentCasts.DTOs;

namespace WatchListMovies.Api.Controllers
{
    public class ContentCastController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public ContentCastController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetContentCastsByFilter")]
        public async Task<ApiResult<ContentCastFilterResult>> GetContentCastsByFilter([FromQuery] ContentCastFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetContentCastsByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
