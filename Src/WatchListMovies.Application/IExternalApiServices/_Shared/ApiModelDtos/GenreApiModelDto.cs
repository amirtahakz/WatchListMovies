using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos
{
    public class GenreApiModelDto
    {
        [JsonProperty("id")]
        public long? ApiModelId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

}
