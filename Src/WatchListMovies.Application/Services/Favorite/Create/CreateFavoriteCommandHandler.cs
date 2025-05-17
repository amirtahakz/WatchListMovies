using WatchListMovies.Common.Application;
using WatchListMovies.Domain.FavoriteAgg.Repository;

namespace WatchListMovies.Application.Services.Favorite.Create;

public class CreateFavoriteCommandHandler : IBaseCommandHandler<CreateFavoriteCommand, Guid>
{
    private readonly IFavoriteRepository _favoriteRepository;

    public CreateFavoriteCommandHandler(IFavoriteRepository favoriteRepository)
    {
        _favoriteRepository = favoriteRepository;
    }
    public async Task<OperationResult<Guid>> Handle(CreateFavoriteCommand request, CancellationToken cancellationToken)
    {
        var entityModel = new Domain.FavoriteAgg.Favorite(request.UserId, request.SubjectId, request.ListId, request.Note, request.FavoriteType);
        await _favoriteRepository.AddAsync(entityModel);
        await _favoriteRepository.Save();

        return OperationResult<Guid>.Success(entityModel.Id);
    }
}