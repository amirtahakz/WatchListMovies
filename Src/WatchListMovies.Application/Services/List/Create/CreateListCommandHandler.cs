using WatchListMovies.Common.Application;
using WatchListMovies.Domain.ListAgg.Repository;

namespace WatchListMovies.Application.Services.List.Create;

public class CreateListCommandHandler : IBaseCommandHandler<CreateListCommand, Guid>
{
    private readonly IListRepository _listRepository;

    public CreateListCommandHandler(IListRepository listRepository)
    {
        _listRepository = listRepository;
    }

    public async Task<OperationResult<Guid>> Handle(CreateListCommand request, CancellationToken cancellationToken)
    {
        var entityModel = new Domain.ListAgg.List(request.UserId, request.Name, request.Description, request.ListType, request.IsPrivate);
        await _listRepository.AddAsync(entityModel);
        await _listRepository.Save();

        return OperationResult<Guid>.Success(entityModel.Id);
    }
}