using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.Favorite;
using WatchListMovies.Application.Services.Favorite.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Companies.DTOs;
using WatchListMovies.Query.Companies.GerByFilter;
using WatchListMovies.Query.Favorites.DTOs;
using WatchListMovies.Query.Favorites.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class CompanyController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public CompanyController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [HttpGet("GetCompaniesByFilter")]
        public async Task<ApiResult<CompanyFilterResult>> GetCompaniesByFilter([FromQuery] CompanyFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetCompaniesByFilterQuery(filterParams));
            return QueryResult(result);
        }
    }
}
