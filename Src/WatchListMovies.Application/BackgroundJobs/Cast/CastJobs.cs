using AutoMapper;
using Microsoft.Extensions.Options;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Cast
{
    public class CastJobs
    {
        private readonly ICastApiService _castApiService;
        private readonly ICastRepository _castRepository;
        private readonly PagesCountForGettingDataTest _pagesCountForGettingDataTest;

        public CastJobs(
            ICastApiService castApiService,
            ICastRepository castRepository,
            IOptions<PagesCountForGettingDataTest> pagesCountForGettingDataTest)
        {
            _castApiService = castApiService;
            _castRepository = castRepository;
            _pagesCountForGettingDataTest = pagesCountForGettingDataTest.Value;
        }

        public async Task SyncPopularCasts()
        {
            try
            {
                for (var page = 1; ; page++)
                {
                    if (_pagesCountForGettingDataTest.CastPageCount != 0 && page == _pagesCountForGettingDataTest.CastPageCount)
                        break;

                    var data = await _castApiService.GetPopularCasts(page);
                    if (data == null || data.Casts == null || !data.Casts.Any()) break;

                    await _castRepository.BulkInsertIfNotExistAsync(data.Casts.Map());

                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task SyncCastDetails()
        {

            try
            {
                const int batchSize = 200;
                long totalCount = await _castRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var casts = await _castRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = casts.Select(async cast =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _castApiService.GetCastDetails(cast.ApiModelId ?? default);
                            cast.CastDetails = apiDetails.Map(cast.Id);
                            return cast;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedCasts = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _castRepository.BulkInsertOrUpdateAsync(updatedCasts.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SyncCastExternalIds()
        {

            try
            {
                const int batchSize = 200;
                long totalCount = await _castRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var casts = await _castRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = casts.Select(async cast =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _castApiService.GetCastExternalIds(cast.ApiModelId);
                            cast.CastExternalId = apiDetails.Map(cast.Id);
                            return cast;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedCasts = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _castRepository.BulkInsertOrUpdateAsync(updatedCasts.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
        
    }
}
