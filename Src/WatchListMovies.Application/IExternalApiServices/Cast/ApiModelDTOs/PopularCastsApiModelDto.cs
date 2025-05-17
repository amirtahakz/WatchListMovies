using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs
{
    public class PopularCastsApiModelDto
    {
        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("results")]
        public List<PopularCastDetailsItem> Results { get; set; }

        [JsonProperty("total_pages")]
        public long? TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long? TotalResults { get; set; }
    }

    public class KnownFor
    {
        [JsonProperty("backdrop_path")]
        public string BackdropPath { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("original_title")]
        public string? OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("media_type")]
        public string? MediaType { get; set; }

        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonProperty("genre_ids")]
        public List<long>? GenreIds { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonProperty("video")]
        public bool? Video { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long? VoteCount { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("original_name")]
        public string? OriginalName { get; set; }

        [JsonProperty("first_air_date")]
        public string? FirstAirDate { get; set; }

        [JsonProperty("origin_country")]
        public List<string>? OriginCountry { get; set; }
    }

    public class PopularCastDetailsItem
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("gender")]
        public long? Gender { get; set; }

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

        [JsonProperty("known_for")]
        public List<KnownFor>? KnownFor { get; set; }
    }
}
