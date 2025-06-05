using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Collection.DTOs;
using WatchListMovies.Query.Collection.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class CollectionController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CollectionController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetCollectionsByFilter")]
        public async Task<ApiResult<CollectionFilterResult>> GetCollectionsByFilter([FromQuery] CollectionFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetCollectionByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
