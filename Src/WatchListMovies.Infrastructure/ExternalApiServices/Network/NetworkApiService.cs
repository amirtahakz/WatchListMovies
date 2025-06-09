using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Network;
using WatchListMovies.Application.IExternalApiServices.Network.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Network
{
    public class NetworkApiService : INetworkApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public NetworkApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }
        public async Task<GetNetworkDetailsApiModelDto> GetNetworkDetails(long? networkApiId)
        {
            var response = await _httpClient.GetAsync($"network/{networkApiId}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetNetworkDetailsApiModelDto>(data);

            return deserializedData;
        }
    }
}
