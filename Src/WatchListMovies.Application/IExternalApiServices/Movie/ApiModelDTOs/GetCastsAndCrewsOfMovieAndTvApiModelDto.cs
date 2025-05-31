using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs
{
    public class GetCastsAndCrewsOfMovieAndTvApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("cast")]
        public List<MovieAndTvCastsItemApiModelDto>? Casts { get; set; }

        [JsonProperty("crew")]
        public List<MovieAndTvCrewsItemApiModelDto>? Crews { get; set; }
    }

    public class MovieAndTvCastsItemApiModelDto
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("gender")]
        public int? Gender { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("known_for_department")]
        public string? KnownForDepartment { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("original_name")]
        public string? OriginalName { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string? ProfilePath { get; set; }

        [JsonProperty("cast_id")]
        public long? CastId { get; set; }

        [JsonProperty("character")]
        public string? Character { get; set; }

        [JsonProperty("credit_id")]
        public string? CreditId { get; set; }

        [JsonProperty("order")]
        public int? Order { get; set; }
    }

    public class MovieAndTvCrewsItemApiModelDto
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("gender")]
        public int? Gender { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("known_for_department")]
        public string? KnownForDepartment { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("original_name")]
        public string? OriginalName { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string? ProfilePath { get; set; }

        [JsonProperty("credit_id")]
        public string? CreditId { get; set; }

        [JsonProperty("department")]
        public string? Department { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }
    }
}
