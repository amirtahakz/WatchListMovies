using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg
{
    public class Tv : BaseEntity
    {
        public Tv()
        {
            
        }

        public Tv(bool? adult,
            string? backdropPath,
            long? apiModelId,
            string? originalLanguage,
            string? originalName,
            string? overview,
            double? popularity,
            string? posterPath,
            DateTime? firstAirDate,
            string? name,
            double? voteAverage,
            long? voteCount,
            IEnumerable<string>? genreIds,
            TvDetail tvDetail,
            bool? isRecommendedByAdmin = false)
        {
            Adult = adult;
            BackdropPath = backdropPath;
            ApiModelId = apiModelId;
            OriginalLanguage = originalLanguage;
            OriginalName = originalName;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            FirstAirDate = firstAirDate;
            Name = name;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            GenreIds = genreIds.ToList();
            TvDetail = tvDetail;
            IsRecommendedByAdmin = isRecommendedByAdmin;
        }

        public void MakeRecommended()
        {
            IsRecommendedByAdmin = true;
        }

        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public DateTime? FirstAirDate { get; set; }
        public string? Name { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public bool? IsRecommendedByAdmin { get; set; }
        public IReadOnlyCollection<string>? GenreIds { get; set; }
        public TvDetail? TvDetail { get; set; }
    }
}
