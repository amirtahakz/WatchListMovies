using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Countries.DTOs;
using WatchListMovies.Query.Countries.GetByFilter;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class CountryController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CountryController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetCountriesByFilter")]
        public async Task<ApiResult<CountryFilterResult>> GetCountriesByFilter([FromQuery] CountryFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetCountriesByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
