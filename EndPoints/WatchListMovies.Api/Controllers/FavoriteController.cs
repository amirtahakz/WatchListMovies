using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.Favorite;

using WatchListMovies.Application.Services.Favorite.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Favorites.DTOs;
using WatchListMovies.Query.Favorites.GetByFilter;
using WatchListMovies.Query.Favorites.GetById;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Lists.GetByFilter;
using ApiController = WatchListMovies.Common.AspNetCore.ApiController;

namespace WatchListMovies.Api.Controllers
{
    [Authorize]
    public class FavoriteController : ApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public FavoriteController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }


        [HttpPost("CreateFavorite")]
        public async Task<ApiResult<Guid>> CreateFavorite([FromQuery]CreateFavoriteViewModel viewModel)
        {
            var command = _mapper.Map<CreateFavoriteCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }

        [HttpGet("GetFavoriteByFilter")]
        public async Task<ApiResult<FavoriteFilterResult>> GetFavoriteByFilter([FromQuery] FavoriteFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetFavoriteByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [HttpGet("GetFavoriteById")]
        public async Task<ApiResult<FavoriteDto>> GetFavoriteById([FromQuery] Guid favoriteId)
        {
            var result = await _mediator.Send(new GetFavoriteByIdQuery(favoriteId));
            return QueryResult(result);
        }
    }
}
