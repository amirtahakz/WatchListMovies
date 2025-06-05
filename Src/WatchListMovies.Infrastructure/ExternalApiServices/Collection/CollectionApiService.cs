using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Collection;
using WatchListMovies.Application.IExternalApiServices.Collection.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Collection
{
    public class CollectionApiService : ICollectionApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public CollectionApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<GetCollectionDetailsApiModelDto> GetCollectionDetails(long collectionApiId)
        {
            var response = await _httpClient.GetAsync($"collection/{collectionApiId}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetCollectionDetailsApiModelDto>(data);

            return deserializedData;
        }
    }
}
