using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs
{
    public class CastDetailsApiModelDto
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("also_known_as")]
        public List<string>? AlsoKnownAs { get; set; }

        [JsonProperty("biography")]
        public string? Biography { get; set; }

        [JsonProperty("birthday")]
        public DateTime? Birthday { get; set; }

        [JsonProperty("deathday")]
        public DateTime? Deathday { get; set; }

        [JsonProperty("gender")]
        public int? Gender { get; set; }

        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("imdb_id")]
        public string? ImdbId { get; set; }

        [JsonProperty("known_for_department")]
        public string? KnownForDepartment { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("place_of_birth")]
        public string? PlaceOfBirth { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string? ProfilePath { get; set; }
    }

    
}
