using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Domain.ContentCastAgg.Enums;
using WatchListMovies.Query.ContentCast.DTOs;
using WatchListMovies.Query.ContentCast.GetByFilter;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetByFilter;

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
