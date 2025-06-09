using WatchListMovies.Application.IExternalApiServices.Collection;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Collection
{
    public class CollectionJobs
    {
        private readonly ICollectionApiService _collectionApiService;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieApiService _movieApiService;

        public CollectionJobs(
            ICollectionApiService collectionApiService,
            ICollectionRepository collectionRepository,
            IMovieRepository movieRepository,
            IMovieApiService movieApiService)
        {
            _collectionApiService = collectionApiService;
            _collectionRepository = collectionRepository;
            _movieRepository = movieRepository;
            _movieApiService = movieApiService;
        }

        public async Task SyncCollections()
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
                            return apiDetails;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedMovies = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _collectionRepository.BulkInsertIfNotExistAsync(
                        updatedMovies
                        .Where(item=>item.BelongsToCollection != null)
                        .Select(item=>item.BelongsToCollection.Map())
                        .ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SyncCollectionDetails()
        {
            try
            {
                const int batchSize = 200;
                long totalCount = await _collectionRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var collections = await _collectionRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = collections.Select(async collection =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _collectionApiService.GetCollectionDetails(collection.ApiModelId ?? default);
                            collection.CollectionDetail = apiDetails.Map(collection.Id);
                            return collection;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedCollections = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _collectionRepository.BulkInsertOrUpdateAsync(updatedCollections.ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
