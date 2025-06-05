using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Configuration.ApiModelDTOs
{
    public class CountriesApiModelDto
    {
        [JsonProperty("iso_3166_1")]
        public string? Iso31661 { get; set; }

        [JsonProperty("english_name")]
        public string? EnglishName { get; set; }

        [JsonProperty("native_name")]
        public string? NativeName { get; set; }
    }
}
