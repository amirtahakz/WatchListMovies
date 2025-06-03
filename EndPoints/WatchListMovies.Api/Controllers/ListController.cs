using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.ViewModels.List;
using WatchListMovies.Application.Services.List.Create;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Lists.GetByFilter;
using WatchListMovies.Query.Lists.GetById;

namespace WatchListMovies.Api.Controllers
{
    public class ListController : BaseApiController
    {
        private readonly IMediator _mediator;
        private readonly IMapper _mapper;

        public ListController(IMediator mediator, IMapper mapper)
        {
            _mediator = mediator;
            _mapper = mapper;
        }

        [Authorize]
        [HttpPost("CreateList")]
        public async Task<ApiResult<Guid>> CreateList([FromQuery] CreateListViewModel viewModel)
        {
            var command = _mapper.Map<CreateListCommand>(viewModel);
            command.UserId = User.GetUserId();
            var result = await _mediator.Send(command);
            return CommandResult(result);
        }

        [HttpGet("GetListsByFilter")]
        public async Task<ApiResult<ListFilterResult>> GetListByFilter([FromQuery] ListFilterParams filterParams)
        {
            var result = await _mediator.Send(new GetListsByFilterQuery(filterParams));
            return QueryResult(result);
        }

        [HttpGet("GetListsById")]
        public async Task<ApiResult<ListDto>> GetListById([FromQuery] Guid listId)
        {
            var result = await _mediator.Send(new GetListByIdQuery(listId));
            return QueryResult(result);
        }
    }
}
