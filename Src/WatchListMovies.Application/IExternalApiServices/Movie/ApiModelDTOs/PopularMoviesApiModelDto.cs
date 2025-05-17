using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs
{
    public class PopularMoviesApiModelDto
    {
        [JsonProperty("page")]
        public int? Page { get; set; }

        [JsonProperty("results")]
        public List<PopularMoviesItem>? Results { get; set; }

        [JsonProperty("total_pages")]
        public long? TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long? TotalResults { get; set; }
    }

    public class PopularMoviesItem
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonProperty("genre_ids")]
        public List<long>? GenreIds { get; set; }

        [JsonProperty("id")]
        public long? ApiModelId { get; set; }

        [JsonProperty("original_language")]
        public string? OriginalLanguage { get; set; }

        [JsonProperty("original_title")]
        public string? OriginalTitle { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("release_date")]
        public string? ReleaseDate { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("video")]
        public bool? Video { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public int? VoteCount { get; set; }
    }

}
