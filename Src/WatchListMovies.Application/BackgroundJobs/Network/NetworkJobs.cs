using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Network;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.ContentImageAgg.Enums;
using WatchListMovies.Domain.ContentImageAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.NetworkAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Network
{
    public class NetworkJobs
    {
        private readonly ITvRepository _tvRepository;
        private readonly ITvApiService _tvApiService;
        private readonly INetworkApiService _networkApiService;
        private readonly INetworkRepository _networkRepository;

        public NetworkJobs(
            ITvRepository tvRepository,
            ITvApiService tvApiService,
            INetworkApiService networkApiService,
            INetworkRepository networkRepository)
        {
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
            _networkApiService = networkApiService;
            _networkRepository = networkRepository;
        }

        public async Task SyncNetworks()
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
                            return apiTvDetails.Networks.Map();
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvNetworks = await Task.WhenAll(castTask);


                    // ذخیره دسته‌ای
                    await _networkRepository.BulkInsertIfNotExistAsync(
                        updatedTvNetworks
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

        public async Task SyncNetworkDetails()
        {
            try
            {
                const int batchSize = 200;
                long totalCount = await _networkRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var networks = await _networkRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = networks.Select(async network =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var networkApi = await _networkApiService.GetNetworkDetails(network.ApiModelId);
                            network.NetworkDetail = networkApi.Map(network.Id);
                            return network;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedNetworks = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _networkRepository.BulkInsertOrUpdateAsync(updatedNetworks.ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
