using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.Cast;
using WatchListMovies.Api.ViewModels.Movie;

using WatchListMovies.Application.Services.Cast.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Cast.DTOs;
using WatchListMovies.Query.Cast.GetByFilter;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Lists.GetByFilter;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class CastController : ApiController
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

        [Authorize]
        [HttpPost("CreateCast")]
        public async Task<ApiResult<Guid>> CreateCast([FromQuery] CreateCastViewModel viewModel)
        {
            var command = _mapper.Map<CreateCastCommand>(viewModel);
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }
    }
}
