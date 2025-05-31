using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs
{
    public class BelongsToCollectionApiModelDto
    {
        [JsonProperty("id")]
        public long? ApiModelId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }
    }
}
