using WatchListMovies.Common.Domain;
using WatchListMovies.Domain._Shared.ValueObjects;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg.ValueObjects;

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
            List<GenreValueObject>? genres,
            List<SeasonValueObject>? seasons,
            List<NetworkValueObject>? networks,
            List<CreatedByValueObject>? createdBys,
            List<ProductionCountryValueObject>? productionCountries,
            List<ProductionCompanyValueObject>? productionCompanies,
            List<SpokenLanguageValueObject>? spokenLanguages,
            List<EpisodeValueObject>? episodeToAirs,
            IEnumerable<string>? tvEpisodeRunTimes,
            List<TvCast>? casts,
            List<TvCrew>? crews)
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
            Genres = genres;
            Seasons = seasons;
            Networks = networks;
            CreatedBys = createdBys;
            ProductionCountries = productionCountries;
            ProductionCompanies = productionCompanies;
            SpokenLanguages = spokenLanguages;
            EpisodeToAirs = episodeToAirs;
            TvEpisodeRunTimes = tvEpisodeRunTimes.ToList();
            Casts = casts;
            Crews = crews;
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
        public List<GenreValueObject>? Genres { get; set; }
        public List<SeasonValueObject>? Seasons { get; set; }
        public List<NetworkValueObject>? Networks { get; set; }
        public List<CreatedByValueObject>? CreatedBys { get; set; }
        public List<ProductionCountryValueObject>? ProductionCountries { get; set; }
        public List<ProductionCompanyValueObject>? ProductionCompanies { get; set; }
        public List<SpokenLanguageValueObject>? SpokenLanguages { get; set; }
        public List<EpisodeValueObject>? EpisodeToAirs { get; set; }
        public IReadOnlyCollection<string>? TvEpisodeRunTimes { get; set; }
        public List<TvCast>? Casts { get; set; }
        public List<TvCrew>? Crews { get; set; }

    }
}
