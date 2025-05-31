using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs
{
    public class SeasonApiModelDto
    {
        [JsonProperty("air_date")]
        public DateTime? AirDate { get; set; }

        [JsonProperty("episode_count")]
        public long? EpisodeCount { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("season_number")]
        public long? SeasonNumber { get; set; }

        [JsonProperty("vote_average")]
        public float? VoteAverage { get; set; }
    }
}
