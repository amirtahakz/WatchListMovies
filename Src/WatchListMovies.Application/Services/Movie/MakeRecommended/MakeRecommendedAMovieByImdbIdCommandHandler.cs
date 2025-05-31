using WatchListMovies.Common.Application;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.Services.Movie.MakeRecommended
{
    public class MakeRecommendedAMovieByImdbIdCommandHandler : IBaseCommandHandler<MakeRecommendedAMovieByImdbIdCommand, bool>
    {
        private readonly IMovieRepository _movieRepository;

        public MakeRecommendedAMovieByImdbIdCommandHandler(IMovieRepository movieRepository)
        {
            _movieRepository = movieRepository;
        }

        public async Task<OperationResult<bool>> Handle(MakeRecommendedAMovieByImdbIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var movie = await _movieRepository.GetTrackingByImdbIdAsync(request.ImdbId);
                if (movie == null)
                    throw new Exception("Movie Not Found.");

                movie.MakeRecommended();
                await _movieRepository.Save();
                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                return OperationResult<bool>.Success(false);

            }

        }
    }
}
