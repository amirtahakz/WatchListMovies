using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos
{
    public class ProductionCountryApiModelDto
    {
        [JsonProperty("iso_3166_1")]
        public string? Iso31661 { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

}
