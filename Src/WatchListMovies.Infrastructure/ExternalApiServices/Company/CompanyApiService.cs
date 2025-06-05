using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Company;
using WatchListMovies.Application.IExternalApiServices.Company.ApiModelDTOs;

namespace WatchListMovies.Infrastructure.ExternalApiServices.Company
{
    public class CompanyApiService : ICompanyApiService
    {
        private readonly HttpClient _httpClient;
        private readonly TMDBConfig _tMDBConfig;

        public CompanyApiService(HttpClient httpClient, IOptions<TMDBConfig> tMDBConfig)
        {
            _httpClient = httpClient;
            _tMDBConfig = tMDBConfig.Value;
        }

        public async Task<GetCompanyDetailsApiModelDto> GetCompanyDetails(long companyApiId)
        {
            var response = await _httpClient.GetAsync($"company/{companyApiId}?api_key={_tMDBConfig.ApiKey}&language={_tMDBConfig.language}");
            response.EnsureSuccessStatusCode();

            var data = await response.Content.ReadAsStringAsync();
            var deserializedData = JsonConvert.DeserializeObject<GetCompanyDetailsApiModelDto>(data);

            return deserializedData;
        }
    }
}
