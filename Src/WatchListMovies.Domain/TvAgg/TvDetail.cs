using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg
{
    public class TvDetail : BaseEntity
    {
        public TvDetail()
        {
            
        }

        public TvDetail(
            Guid tvId,
            long? apiModelId,
            bool? adult,
            string? backdropPath,
            string? firstAirDate,
            string? homepage,
            bool? inProduction,
            string? lastAirDate,
            string? name,
            long? numberOfEpisodes,
            long? numberOfSeasons,
            string? originalLanguage,
            string? originalName,
            string? overview,
            double? popularity,
            string? posterPath,
            string? status,
            string? tagline,
            string? type,
            double? voteAverage,
            long? voteCount,
            IEnumerable<string>? genreIds,
            IEnumerable<string>? tvEpisodeRunTimes,
            IReadOnlyCollection<string>? companyIds,
            IReadOnlyCollection<string>? countryIds,
            IReadOnlyCollection<string>? languageIds,
            IReadOnlyCollection<string>? createdByApiIds,
            IReadOnlyCollection<string>? networkds)
        {
            TvId = tvId;
            ApiModelId = apiModelId;
            Adult = adult;
            BackdropPath = backdropPath;
            FirstAirDate = firstAirDate;
            Homepage = homepage;
            InProduction = inProduction;
            LastAirDate = lastAirDate;
            Name = name;
            NumberOfEpisodes = numberOfEpisodes;
            NumberOfSeasons = numberOfSeasons;
            OriginalLanguage = originalLanguage;
            OriginalName = originalName;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            Status = status;
            Tagline = tagline;
            Type = type;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            GenreIds = genreIds.ToList();
            TvEpisodeRunTimes = tvEpisodeRunTimes.ToList();
            CompanyIds = companyIds;
            CountryIds = countryIds;
            LanguageIds = languageIds;
            CreatedByIds = createdByApiIds;
            NetworkIds = networkds;
        }
        public Guid TvId { get; set; }
        public long? ApiModelId { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public string? FirstAirDate { get; set; }
        public string? Homepage { get; set; }
        public bool? InProduction { get; set; } //در حال ساخت 
        public string? LastAirDate { get; set; }
        public string? Name { get; set; }
        public long? NumberOfEpisodes { get; set; }
        public long? NumberOfSeasons { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? Status { get; set; }
        public string? Tagline { get; set; }
        public string? Type { get; set; }
        public double? VoteAverage { get; set; } // امتیاز سایت TMDB
        public long? VoteCount { get; set; }
        public IReadOnlyCollection<string>? NetworkIds { get; set; }
        public IReadOnlyCollection<string>? GenreIds { get; set; }
        public IReadOnlyCollection<string>? CreatedByIds { get; set; }
        public IReadOnlyCollection<string>? CompanyIds { get; set; }
        public IReadOnlyCollection<string>? CountryIds { get; set; }
        public IReadOnlyCollection<string>? LanguageIds { get; set; }
        public IReadOnlyCollection<string>? TvEpisodeRunTimes { get; set; }

    }
}
