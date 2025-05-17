using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Genre;
using WatchListMovies.Application.IExternalApiServices.Genre.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Genre
{
    public class GenreApiService : IGenreApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public GenreApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<GetGenresApiModelDto> GetMovieGenres()
        {
            var response = await _httpClient.GetAsync($"genre/movie/list?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetGenresApiModelDto>(data);

            return deserializedData;
        }

        public async Task<GetGenresApiModelDto> GetTvGenres()
        {
            var response = await _httpClient.GetAsync($"genre/tv/list?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetGenresApiModelDto>(data);

            return deserializedData;
        }
    }
}
