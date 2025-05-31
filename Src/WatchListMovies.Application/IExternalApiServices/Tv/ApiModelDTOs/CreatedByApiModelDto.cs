using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs
{
    public class CreatedByApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("credit_id")]
        public string? CreditId { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("original_name")]
        public string? OriginalName { get; set; }

        [JsonProperty("gender")]
        public int? Gender { get; set; }

        [JsonProperty("profile_path")]
        public string? ProfilePath { get; set; }
    }
}
