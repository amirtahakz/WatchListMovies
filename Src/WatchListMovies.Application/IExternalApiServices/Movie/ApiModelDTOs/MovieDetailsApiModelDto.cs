using Newtonsoft.Json;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;

namespace WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs
{
    public class MovieDetailsApiModelDto
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }

        [JsonProperty("budget")]
        public long? Budget { get; set; }  

        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        [JsonProperty("id")]
        public long? ApiModelId { get; set; }

        [JsonProperty("imdb_id")]
        public string? ImdbId { get; set; }

        [JsonProperty("origin_country")]
        public List<string>? OriginCountry { get; set; }

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
        public DateTime? ReleaseDate { get; set; }

        [JsonProperty("revenue")]
        public long? Revenue { get; set; }

        [JsonProperty("runtime")]
        public long? Runtime { get; set; } 

        [JsonProperty("status")]
        public string? Status { get; set; }

        [JsonProperty("tagline")]
        public string? Tagline { get; set; }

        [JsonProperty("title")]
        public string? Title { get; set; }

        [JsonProperty("video")]
        public bool? Video { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long? VoteCount { get; set; }


        [JsonProperty("belongs_to_collection")]
        public BelongsToCollectionApiModelDto? BelongsToCollection { get; set; }

        [JsonProperty("genres")]
        public List<GenreApiModelDto>? Genres { get; set; }

        [JsonProperty("production_companies")]
        public List<ProductionCompanyApiModelDto>? ProductionCompanies { get; set; }

        [JsonProperty("production_countries")]
        public List<ProductionCountryApiModelDto>? ProductionCountries { get; set; }

        [JsonProperty("spoken_languages")]
        public List<SpokenLanguageApiModelDto>? SpokenLanguages { get; set; }
    }
}
