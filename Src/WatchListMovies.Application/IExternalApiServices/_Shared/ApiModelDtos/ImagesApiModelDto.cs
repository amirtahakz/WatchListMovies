using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos
{
    public class ImagesApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("profiles")]
        public List<ImagesItemApiModelDto>? Images { get; set; }
    }
    public class ImagesItemApiModelDto
    {
        [JsonProperty("aspect_ratio")]
        public double? AspectRatio { get; set; }

        [JsonProperty("height")]
        public long? Height { get; set; }

        [JsonProperty("iso_639_1")]
        public string? Iso6391 { get; set; }

        [JsonProperty("file_path")]
        public string? FilePath { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long? VoteCount { get; set; }

        [JsonProperty("width")]
        public long? Width { get; set; }
    }

}
