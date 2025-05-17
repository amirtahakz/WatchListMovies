using WatchListMovies.Common.Domain;
using WatchListMovies.Domain._Shared.ValueObjects;
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
            List<Genre>? genres,
            List<Season>? seasons,
            List<Network>? networks,
            List<CreatedBy>? createdBys,
            List<ProductionCountry>? productionCountries,
            List<ProductionCompany>? productionCompanies,
            List<SpokenLanguage>? spokenLanguages,
            List<Episode>? episodeToAirs,
            IEnumerable<string>? tvEpisodeRunTimes)
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
        }
        public Guid TvId { get; set; }
        public long? ApiModelId { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public string? FirstAirDate { get; set; }
        public string? Homepage { get; set; }
        public bool? InProduction { get; set; }
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
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public List<Genre>? Genres { get; set; }
        public List<Season>? Seasons { get; set; }
        public List<Network>? Networks { get; set; }
        public List<CreatedBy>? CreatedBys { get; set; }
        public List<ProductionCountry>? ProductionCountries { get; set; }
        public List<ProductionCompany>? ProductionCompanies { get; set; }
        public List<SpokenLanguage>? SpokenLanguages { get; set; }
        public List<Episode>? EpisodeToAirs { get; set; }
        public IReadOnlyCollection<string>? TvEpisodeRunTimes { get; set; }

    }
}
