using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs
{
    public class EpisodeApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("vote_average")]
        public float? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long? VoteCount { get; set; }

        [JsonProperty("air_date")]
        public DateTime? AirDate { get; set; }

        [JsonProperty("episode_number")]
        public long? EpisodeNumber { get; set; }

        [JsonProperty("episode_type")]
        public string? EpisodeType { get; set; }

        [JsonProperty("production_code")]
        public string? ProductionCode { get; set; }

        [JsonProperty("runtime")]
        public long? Runtime { get; set; }

        [JsonProperty("season_number")]
        public long? SeasonNumber { get; set; }

        [JsonProperty("show_id")]
        public long? ShowId { get; set; }

        [JsonProperty("still_path")]
        public string? StillPath { get; set; }
    }
}
