using WatchListMovies.Common.Query;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Query.Tvs.DTOs
{
    public class TvDto : BaseDto
    {
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
        public TvDetail? TvDetail { get; set; }
    }
}
