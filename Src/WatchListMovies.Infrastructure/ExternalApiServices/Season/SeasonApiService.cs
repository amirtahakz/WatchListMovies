using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Network.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Season;
using WatchListMovies.Application.IExternalApiServices.Season.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Season
{
    public class SeasonApiService : ISeasonApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public SeasonApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<GetSeasonDetailsApiModelDto> GetSeasonDetails(long tvApiId , int seasonNumber)
        {
            var response = await _httpClient.GetAsync($"tv/{tvApiId}/season/{seasonNumber}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetSeasonDetailsApiModelDto>(data);

            return deserializedData;
        }
    }
}
