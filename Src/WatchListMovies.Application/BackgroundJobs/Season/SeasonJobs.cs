using System.Linq;
using WatchListMovies.Application.BackgroundJobs.Network;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.NetworkAgg.Repository;
using WatchListMovies.Domain.SeasonAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Season
{
    public class SeasonJobs
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly ITvRepository _tvRepository;
        private readonly ITvApiService _tvApiService;

        public SeasonJobs(
            ISeasonRepository seasonRepository,
            ITvRepository tvRepository,
            ITvApiService tvApiService)
        {
            _seasonRepository = seasonRepository;
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
        }

        public async Task SyncSeasons()
        {
            try
            {
                const int batchSize = 100;
                long totalCount = await _tvRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var tvs = await _tvRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var castTask = tvs.Select(async tv =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiTvDetails = await _tvApiService.GetTvDetails(tv.ApiModelId);
                            return apiTvDetails.Seasons.Map(tv.ApiModelId);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvSeasons = await Task.WhenAll(castTask);


                    // ذخیره دسته‌ای
                    await _seasonRepository.BulkInsertIfNotExistAsync(
                        updatedTvSeasons
                        .SelectMany(m => m) // flatten
                        .Select(cast => cast) // تبدیل به domain model یا entity
                        .ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
