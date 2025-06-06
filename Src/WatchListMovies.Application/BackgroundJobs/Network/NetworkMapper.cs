using WatchListMovies.Application.IExternalApiServices.Network.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;

namespace WatchListMovies.Application.BackgroundJobs.Network
{
    public static class NetworkMapper
    {
        public static Domain.NetworkAgg.Network Map(this NetworkApiModelDto networkApi)
        {
            var result = new Domain.NetworkAgg.Network()
            {
                ApiModelId = networkApi.Id,
                Name = networkApi.Name,
                LogoPath = networkApi.LogoPath,
                OriginCountry = networkApi.OriginCountry,
            };
            return result;
        }
        

        public static List<Domain.NetworkAgg.Network> Map(this List<NetworkApiModelDto> networkApis)
        {
            var result = new List<Domain.NetworkAgg.Network>();

            foreach (var networkApi in networkApis)
                result.Add(networkApi.Map());

            return result;
        }

        public static Domain.NetworkAgg.NetworkDetail Map(this GetNetworkDetailsApiModelDto requestModel , Guid parrentId)
        {
            var result = new Domain.NetworkAgg.NetworkDetail()
            {
                ApiModelId = requestModel.Id,
                Headquarters = requestModel.Headquarters,
                Homepage = requestModel.Homepage,
                LogoPath = requestModel.LogoPath,
                Name = requestModel.Name,
                OriginCountry = requestModel.OriginCountry,
                ParrentId = parrentId,
            };
            return result;
        }
    }
}
