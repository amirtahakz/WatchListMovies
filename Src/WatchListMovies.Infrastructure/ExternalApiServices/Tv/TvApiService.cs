using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Tv
{
    public class TvApiService : ITvApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public TvApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }
        public async Task<PopularTvsApiModelDto> GetPopularTvs(int page = 1)
        {
            var response = await _httpClient.GetAsync($"tv/popular?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}&page={page}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<PopularTvsApiModelDto>(data);

            return deserializedData;
        }

        public async Task<TvDetailsApiModelDto> GetTvDetails(long? tvApiId)
        {
            var response = await _httpClient.GetAsync($"tv/{tvApiId}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<TvDetailsApiModelDto>(data);

            return deserializedData;
        }

        public async Task<GetCastsAndCrewsOfMovieAndTvApiModelDto> GetCastsAndCrewsOfTv(long? tvApiId)
        {
            var response = await _httpClient.GetAsync($"tv/{tvApiId}/credits?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}&page=1");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetCastsAndCrewsOfMovieAndTvApiModelDto>(data);

            return deserializedData;
        }
    }
}
