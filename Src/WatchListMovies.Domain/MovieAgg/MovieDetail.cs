using WatchListMovies.Common.Domain;


namespace WatchListMovies.Domain.MovieAgg
{
    public class MovieDetail : BaseEntity
    {
        public MovieDetail()
        {
            
        }

        public MovieDetail(
            Guid movieId,
            bool? adult,
            string? backdropPath,
            long? budget,
            string? homepage,
            long? apiModelId,
            string? imdbId,
            string? originalLanguage,
            string? originalTitle,
            string? overview,
            double? popularity,
            string? posterPath,
            DateTime? releaseDate,
            long? revenue,
            long? runtime,
            string? status,
            string? tagline,
            string? title,
            bool? video,
            double? voteAverage,
            long? voteCount,
            List<MovieKeyYoutubeTrailer>? movieKeyYoutubeTrailers,
            IEnumerable<string>? genreIds,
            IReadOnlyCollection<string>? companyIds,
            IReadOnlyCollection<string>? countryIds,
            IReadOnlyCollection<string>? languageIds,
            long? collectionApiId)
        {
            MovieId = movieId;
            Adult = adult;
            BackdropPath = backdropPath;
            Budget = budget;
            Homepage = homepage;
            ApiModelId = apiModelId;
            ImdbId = imdbId;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            ReleaseDate = releaseDate;
            Revenue = revenue;
            Runtime = runtime;
            Status = status;
            Tagline = tagline;
            Title = title;
            Video = video;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            MovieKeyYoutubeTrailers = movieKeyYoutubeTrailers;
            GenreIds = genreIds.ToList();
            CompanyIds = companyIds;
            CountryIds = countryIds;
            LanguageIds = languageIds;
            CollectionApiId = collectionApiId;
        }

        public Guid MovieId { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? Budget { get; set; }
        public string? Homepage { get; set; }
        public long? ApiModelId { get; set; }
        public string? ImdbId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public long? Runtime { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public long? CollectionApiId { get; set; }
        public List<MovieKeyYoutubeTrailer>? MovieKeyYoutubeTrailers { get; set; }
        public IReadOnlyCollection<string>? GenreIds { get; set; }
        public IReadOnlyCollection<string>? CompanyIds { get; set; }
        public IReadOnlyCollection<string>? CountryIds { get; set; }
        public IReadOnlyCollection<string>? LanguageIds { get; set; }

    }

}
