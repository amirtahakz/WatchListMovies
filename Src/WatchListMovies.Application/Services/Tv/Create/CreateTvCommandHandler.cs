using WatchListMovies.Common.Application;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.Services.Tv.Create;

public class CreateTvCommandHandler : IBaseCommandHandler<CreateTvCommand, Guid>
{
    private readonly ITvRepository _tvRepository;

    public CreateTvCommandHandler(ITvRepository tvRepository)
    {
        _tvRepository = tvRepository;
    }

    public async Task<OperationResult<Guid>> Handle(CreateTvCommand request, CancellationToken cancellationToken)
    {
        var entityModel = new Domain.TvAgg.Tv(request.Adult, request.BackdropPath, request.ApiModelId, request.OriginalLanguage, request.OriginalName
        , request.Overview, request.Popularity, request.PosterPath, request.FirstAirDate, request.Name, request.VoteAverage, request.VoteCount,request.GenreIds , request.TvDetail);
        await _tvRepository.AddAsync(entityModel);
        await _tvRepository.Save();

        return OperationResult<Guid>.Success(entityModel.Id);
    }
}