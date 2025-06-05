using WatchListMovies.Common.Query;

namespace WatchListMovies.Query.Casts.DTOs
{
    public class CastFilterParams : BaseFilterParam
    {
        public Guid? Id { get; set; }
        public long? Gender { get; set; }
        public List<long>? ApiModelIds { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public bool? IsRecommendedByAdmin { get; set; }

        //CastDetail
        public DateTime? StartBirthday { get; set; }
        public DateTime? EndBirthday { get; set; }
        public DateTime? StartDeathday { get; set; }
        public DateTime? EndDeathday { get; set; }
        public string? ImdbId { get; set; }
        public IReadOnlyCollection<string>? CastAlsoKnownAss { get; set; }
    }
}
