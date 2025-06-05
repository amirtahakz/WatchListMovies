using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Company.ApiModelDTOs
{
    public class GetCompanyDetailsApiModelDto
    {
        [JsonProperty("description")]
        public string? Description { get; set; }

        [JsonProperty("headquarters")]
        public string? Headquarters { get; set; }

        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("logo_path")]
        public string? LogoPath { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("origin_country")]
        public string? OriginCountry { get; set; }

        [JsonProperty("parent_company")]
        public ParentCompanyApiModelDto? ParentCompany { get; set; }
    }
    public class ParentCompanyApiModelDto
    {
        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("logo_path")]
        public string? LogoPath { get; set; }
    }
}
