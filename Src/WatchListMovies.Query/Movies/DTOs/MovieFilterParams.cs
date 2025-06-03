using WatchListMovies.Common.Query;
using WatchListMovies.Domain.MovieAgg.Enums;

namespace WatchListMovies.Query.Movies.DTOs
{
    public class MovieFilterParams : BaseFilterParam 
    {
        public MovieOrderByEnum MovieOrderByEnum { get; set; }
        public Guid? Id { get; set; }
        public bool? Adult { get; set; }
        public List<long>? ApiModelIds { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public DateTime? StartReleaseDate { get; set; }
        public DateTime? EndReleaseDate { get; set; }
        public string? Title { get; set; }

        // MovieDetails
        public string? ImdbId { get; set; }
        public List<long>? GenreIds { get; set; }

        // MovieDetails.BelongsToCollectionValueObject
        public string? CollectionName { get; set; }

        // MovieDetails.ProductionCompanies
        public List<string>? CompanyNames { get; set; }

        // MovieDetails.ProductionCountries
        public List<string>? CountryNames { get; set; }

        // MovieDetails.SpokenLanguages
        public List<string>? SpokenLanguageEnglishNames { get; set; }


    }
}
