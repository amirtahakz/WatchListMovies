using WatchListMovies.Common.Query;
using WatchListMovies.Domain.CastAgg;


namespace WatchListMovies.Query.Cast.DTOs
{
    public class CastDto : BaseDto
    {
        public bool? Adult { get; set; }
        public long? Gender { get; set; }
        public long? ApiModelId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public bool? IsRecommendedByAdmin { get; set; }
        public CastExternalId? CastExternalId { get; set; }
        public CastDetail? CastDetails { get; set; }
        public IReadOnlyCollection<string>? MovieKnownForIds { get; set; }
    }
}
