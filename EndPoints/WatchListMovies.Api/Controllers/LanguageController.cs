using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Countries.DTOs;
using WatchListMovies.Query.Countries.GetByFilter;
using WatchListMovies.Query.Languages.DTOs;
using WatchListMovies.Query.Languages.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class LanguageController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public LanguageController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetLanguagesByFilter")]
        public async Task<ApiResult<LanguageFilterResult>> GetLanguagesByFilter([FromQuery] LanguageFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetLanguagesByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
