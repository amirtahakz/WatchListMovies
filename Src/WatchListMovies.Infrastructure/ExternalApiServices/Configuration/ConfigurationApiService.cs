using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Configuration;
using WatchListMovies.Application.IExternalApiServices.Configuration.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Genre.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Configuration
{
    public class ConfigurationApiService : IConfigurationApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public ConfigurationApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<List<LanguagesApiModelDto>> GetLanguagesList()
        {
            var response = await _httpClient.GetAsync($"configuration/languages?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<List<LanguagesApiModelDto>>(data);

            return deserializedData;
        }

        public async Task<List<CountriesApiModelDto>> GetCountriesList()
        {
            var response = await _httpClient.GetAsync($"configuration/countries?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<List<CountriesApiModelDto>>(data);

            return deserializedData;
        }
    }
}
