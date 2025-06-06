using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Season.ApiModelDTOs
{
    public class GetSeasonDetailsApiModelDto
    {

        [JsonProperty("episodes")]
        public List<GetSeasonDetailsEpisodeApiModelDto>? Episodes { get; set; }

    }

    public class GetSeasonDetailsEpisodeApiModelDto
    {
        [JsonProperty("air_date")]
        public DateTime? AirDate { get; set; }

        [JsonProperty("episode_number")]
        public int? EpisodeNumber { get; set; }

        [JsonProperty("episode_type")]
        public string? EpisodeType { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("production_code")]
        public string? ProductionCode { get; set; }

        [JsonProperty("runtime")]
        public int? Runtime { get; set; }

        [JsonProperty("season_number")]
        public int? SeasonNumber { get; set; }

        [JsonProperty("show_id")]
        public int? ShowId { get; set; }

        [JsonProperty("still_path")]
        public string? StillPath { get; set; }

        [JsonProperty("vote_average")]
        public float? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }
    }
}
