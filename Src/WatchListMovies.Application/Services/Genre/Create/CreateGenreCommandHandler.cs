
using WatchListMovies.Common.Application;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.Services.Genre.Create
{
    public class CreateGenreCommandHandler : IBaseCommandHandler<CreateGenreCommand, Guid>
    {
        private readonly IGenreRepository _genreRepository;

        public CreateGenreCommandHandler(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }

        public async Task<OperationResult<Guid>> Handle(CreateGenreCommand request, CancellationToken cancellationToken)
        {
            var entityModel = new Domain.GenreAgg.Genre(request.ApiModelId, request.Name, request.GenreType);
            await _genreRepository.AddAsync(entityModel);
            await _genreRepository.Save();

            return OperationResult<Guid>.Success(entityModel.Id);
        }
    }
}
