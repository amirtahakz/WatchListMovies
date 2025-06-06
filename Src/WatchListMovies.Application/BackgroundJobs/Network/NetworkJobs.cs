using WatchListMovies.Application.IExternalApiServices.Network;
using WatchListMovies.Application.IExternalApiServices.Tv;
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
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Any())
                {
                    foreach (var item in tvs)
                    {
                        var apiNetworkDetails = await _tvApiService.GetTvDetails(item.ApiModelId ?? default);
                        await _networkRepository.AddRangeIfNotExistAsync(apiNetworkDetails.Networks.Map());
                        await _networkRepository.Save();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncNetworkDetails()
        {
            try
            {
                var networks = await _networkRepository.GetAllAsync();

                if (networks.Any())
                {
                    foreach (var item in networks)
                    {
                        var networkApi = await _networkApiService.GetNetworkDetails((long)item.ApiModelId);
                        item.NetworkDetail = networkApi.Map(item.Id);
                        await _networkRepository.Save();

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
