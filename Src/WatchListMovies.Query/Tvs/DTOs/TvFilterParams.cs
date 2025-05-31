using WatchListMovies.Common.Query;
using WatchListMovies.Domain.TvAgg.Enums;

namespace WatchListMovies.Query.Tvs.DTOs
{
    public class TvFilterParams : BaseFilterParam
    {
        public TvOrderByEnum TvOrderByEnum { get; set; }
        public Guid? Id { get; set; }
        public bool? Adult { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public DateTime? StartFirstAirDate { get; set; }
        public DateTime? EndFirstAirDate { get; set; }
        public double? StartVoteAverage { get; set; } // امتیاز سایت TMDB
        public double? EndVoteAverage { get; set; } // امتیاز سایت TMDB
        public string? Name { get; set; }

        //TvDetails
        public bool? InProduction { get; set; } //در حال ساخت 

        // TvDetails.Genres
        public List<long>? GenreIds { get; set; }
        public List<string>? GenreNames { get; set; }

        // TvDetails.CreatedBys
        public string? CreatedByName { get; set; }
        public string? CreatedByOriginalName { get; set; }
        public int? CreatedByGender { get; set; }

        // TvDetails.ProductionCompanies
        public List<string>? CompanyNames { get; set; }

        // TvDetails.ProductionCountries
        public List<string>? CountryNames { get; set; }

        // TvDetails.SpokenLanguages
        public List<string>? SpokenLanguageEnglishNames { get; set; }
    }
}
