using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.Genre;
using WatchListMovies.Application.Services.Genre.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Genre.DTOs;
using WatchListMovies.Query.Genre.GetByFilter;

namespace WatchListMovies.Api.Controllers
{
    public class GenreController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;
        public GenreController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }
        [HttpGet("GetGenresByFilter")]
        public async Task<ApiResult<GenreFilterResult>> GetGenresByFilter([FromQuery] GenreFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetGenresByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [Authorize]
        [HttpPost("CreateGenre")]
        public async Task<ApiResult<Guid>> CreateGenre([FromQuery] CreateGenreViewModel viewModel)
        {
            var command = _mapper.Map<CreateGenreCommand>(viewModel);
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }
    }
}
