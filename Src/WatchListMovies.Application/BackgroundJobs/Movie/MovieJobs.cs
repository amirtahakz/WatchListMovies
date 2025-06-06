using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public class MovieJobs
    {
        private readonly IMovieApiService _movieApiService;
        private readonly IMovieRepository _movieRepository;
        private readonly ICompanyRepository _companyRepository;

        public MovieJobs(
            IMovieApiService movieApiService,
            IMovieRepository movieRepository,
            ICompanyRepository companyRepository)
        {
            _movieApiService = movieApiService;
            _movieRepository = movieRepository;
            _companyRepository = companyRepository;
        }

        public async Task SyncPopularMovies()
        {
            try
            {
                var apiMovies = await _movieApiService.GetPopularMovies(1);

                for (var page = 2; page <= apiMovies.TotalPages; page++)
                {
                    var data = await _movieApiService.GetPopularMovies(page);

                    foreach (var item in data.movies)
                    {
                        if (!apiMovies.movies.Any(v=>v.ApiModelId == item.ApiModelId))
                            apiMovies.movies.Add(item);
                    }
                }

                await _movieRepository.AddRangeIfNotExistAsync(apiMovies.Map());
                await _movieRepository.Save();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SyncMovieDetails()
        {

            try
            {
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        var apiMovieDetails = await _movieApiService.GetMovieDetails(movie.ApiModelId ?? default);
                        movie.MovieDetails = apiMovieDetails.Map(movie.Id);
                        await _movieRepository.Save();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}
