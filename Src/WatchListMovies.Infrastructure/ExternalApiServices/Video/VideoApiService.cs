using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Video;
using WatchListMovies.Application.IExternalApiServices.Video.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Video
{
    public class VideoApiService : IVideoApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public VideoApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }
        public async Task<GetVideosApiModelDto> GetMovieVideos(long? movieApiId)
        {
            var response = await _httpClient.GetAsync($"movie/{movieApiId}/videos?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetVideosApiModelDto>(data);

            return deserializedData;
        }

        public async Task<GetVideosApiModelDto> GetTvVideos(long? tvApiId)
        {
            var response = await _httpClient.GetAsync($"tv/{tvApiId}/videos?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetVideosApiModelDto>(data);

            return deserializedData;
        }
    }
}
