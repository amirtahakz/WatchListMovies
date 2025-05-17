using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.Tv;
using WatchListMovies.Application.Services.Tv.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Tvs.DTOs;
using WatchListMovies.Query.Tvs.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class TvController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public TvController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetTvsByFilter")]
        public async Task<ApiResult<TvFilterResult>> GetTvsByFilter([FromQuery] TvFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetTvByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [Authorize]
        [HttpPost("CreateTv")]
        public async Task<ApiResult<Guid>> CreateTv([FromQuery] CreateTvViewModel viewModel)
        {
            var command = _mapper.Map<CreateTvCommand>(viewModel);
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }
    }
}
