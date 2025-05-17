using WatchListMovies.Common.Domain;
using WatchListMovies.Domain._Shared.ValueObjects;
using WatchListMovies.Domain.MovieAgg.ValueObjects;
using Genre = WatchListMovies.Domain._Shared.ValueObjects.Genre;

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
            string? releaseDate,
            long? revenue,
            long? runtime,
            string? status,
            string? tagline,
            string? title,
            bool? video,
            double? voteAverage,
            long? voteCount,
            BelongsToCollection? belongsToCollection,
            List<Genre> genres,
            List<ProductionCompany> productionCompanies,
            List<ProductionCountry> productionCountries,
            List<SpokenLanguage> spokenLanguages)
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
            BelongsToCollection = belongsToCollection;
            Genres = genres;
            ProductionCompanies = productionCompanies;
            ProductionCountries = productionCountries;
            SpokenLanguages = spokenLanguages;
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
        public string? ReleaseDate { get; set; }
        public long? Revenue { get; set; }
        public long? Runtime { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public BelongsToCollection? BelongsToCollection { get; set; }
        public List<Genre> Genres { get; set; }
        public List<ProductionCompany> ProductionCompanies { get; set; }
        public List<ProductionCountry> ProductionCountries { get; set; }
        public List<SpokenLanguage> SpokenLanguages { get; set; }

    }

}
