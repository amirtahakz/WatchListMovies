using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Movie
{
    public class MovieApiService : IMovieApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public MovieApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<PopularMoviesApiModelDto> GetPopularMovies(int page = 1)
        {
            var response = await _httpClient.GetAsync($"movie/popular?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}&page={page}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<PopularMoviesApiModelDto>(data);

            return deserializedData;
        }

        public async Task<MovieDetailsApiModelDto> GetMovieDetails(long? movieApiId)
        {

            var response = await _httpClient.GetAsync($"movie/{movieApiId}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<MovieDetailsApiModelDto>(data);

            return deserializedData;
        }

        public async Task<MovieKeyYoutubeTrailersApiModelDto> GetMovieYoutubeTrailerKeys(long? movieApiId)
        {
            var response = await _httpClient.GetAsync($"movie/{movieApiId}/videos?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<MovieKeyYoutubeTrailersApiModelDto>(data);

            return deserializedData;
        }
        
    }
}
