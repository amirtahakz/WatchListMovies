using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs
{
    public class NetworkApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("logo_path")]
        public string? LogoPath { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("origin_country")]
        public string? OriginCountry { get; set; }
    }
}
