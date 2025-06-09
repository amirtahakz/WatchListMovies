using System.Threading;
using WatchListMovies.Application.BackgroundJobs.Collection;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.MovieAgg.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public class MovieJobs
    {
        private readonly IMovieApiService _movieApiService;
        private readonly IMovieRepository _movieRepository;
        private readonly ICollectionRepository _collectionRepository;

        public MovieJobs(
            IMovieApiService movieApiService,
            IMovieRepository movieRepository,
            ICollectionRepository collectionRepository)
        {
            _movieApiService = movieApiService;
            _movieRepository = movieRepository;
            _collectionRepository = collectionRepository;
        }

        public async Task SyncPopularMovies()
        {
            try
            {
                for (var page = 1; ; page++)
                {
                    var data = await _movieApiService.GetPopularMovies(page);
                    if (data == null || data.Movies == null || !data.Movies.Any()) break;

                    await _movieRepository.BulkInsertIfNotExistAsync(data.Movies.Map());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SyncMovieDetails()
        {

            try
            {
                const int batchSize = 200;
                long totalCount = await _movieRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var movies = await _movieRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = movies.Select(async movie =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _movieApiService.GetMovieDetails(movie.ApiModelId ?? default);
                            movie.MovieDetails = apiDetails.Map(movie.Id);
                            return movie;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedMovies = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _movieRepository.BulkInsertOrUpdateAsync(updatedMovies.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }

}
