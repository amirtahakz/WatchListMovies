using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Query.Collections.DTOs;
using WatchListMovies.Query.Networks.DTOs;

namespace WatchListMovies.Query.Networks
{
    public static class NetworkMapper
    {
        public static NetworkDto Map(this Domain.NetworkAgg.Network network)
        {
            return new NetworkDto()
            {
                ApiModelId = network.ApiModelId,
                NetworkDetail = network.NetworkDetail,
                Name = network.Name,
                CreationDate = network.CreationDate,
                Id = network.Id,
                LogoPath = network.LogoPath,
                OriginCountry = network.OriginCountry,
            };
        }

        public static List<NetworkDto> Map(this List<Domain.NetworkAgg.Network> networks)
        {
            var result = new List<NetworkDto>();

            foreach (var item in networks)
                result.Add(item.Map());

            return result;
        }
    }
}
