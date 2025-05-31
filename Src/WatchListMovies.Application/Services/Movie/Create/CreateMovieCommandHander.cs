using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Application;
using WatchListMovies.Domain.ListAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.Services.Movie.Create
{
    public class CreateMovieCommandHander : IBaseCommandHandler<CreateMovieCommand, Guid>
    {
        private readonly IMovieRepository _movieRepository;

        public CreateMovieCommandHander(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<OperationResult<Guid>> Handle(CreateMovieCommand request, CancellationToken cancellationToken)
        {
            var entityModel = new Domain.MovieAgg.Movie(request.Adult, request.BackdropPath, request.ApiModelId, request.OriginalLanguage,
                request.OriginalTitle, request.Overview, request.Popularity, request.PosterPath, request.ReleaseDate, request.Title, request.Video, request.VoteAverage,
                request.VoteCount , request.GenreIds , request.MovieDetails , request.IsRecommendedByAdmin);
            await _movieRepository.AddAsync(entityModel);
            await _movieRepository.Save();

            return OperationResult<Guid>.Success(entityModel.Id);
        }
    }

}
