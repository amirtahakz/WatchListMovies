using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Cast
{
    public class CastApiService : ICastApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public CastApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<PopularCastsApiModelDto> GetPopularCasts(int page = 1)
        {
            var response = await _httpClient.GetAsync($"person/popular?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}&page={page}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<PopularCastsApiModelDto>(data);

            return deserializedData;
        }
        public async Task<CastDetailsApiModelDto> GetCastDetails(long? castApiId)
        {
            var response = await _httpClient.GetAsync($"person/{castApiId}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<CastDetailsApiModelDto>(data);

            return deserializedData;
        }

        public async Task<CastExternalIdsApiModelDto> GetCastExternalIds(long? castApiId)
        {
            var response = await _httpClient.GetAsync($"person/{castApiId}/external_ids?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<CastExternalIdsApiModelDto>(data);

            return deserializedData;
        }

        public async Task<ImagesApiModelDto> GetCastImages(long? castApiId)
        {
            var response = await _httpClient.GetAsync($"person/{castApiId}/images?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<ImagesApiModelDto>(data);

            return deserializedData;
        }

        public async Task<GetCreditsOfCastApiModelDto> GetMovieCreditsOfCast(long? castApiId)
        {
            var response = await _httpClient.GetAsync($"person/{castApiId}/movie_credits?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetCreditsOfCastApiModelDto>(data);

            return deserializedData;
        }

        public async Task<GetCreditsOfCastApiModelDto> GetTvCreditsOfCast(long? castApiId)
        {
            var response = await _httpClient.GetAsync($"person/{castApiId}/tv_credits?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetCreditsOfCastApiModelDto>(data);

            return deserializedData;
        }
    }
}
