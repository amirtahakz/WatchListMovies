using WatchListMovies.Common.Query;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.ValueObjects;

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
        public List<CastImage>? CastImages { get; set; }
        public CastExternalId? CastExternalId { get; set; }
        public CastDetail? CastDetails { get; set; }
        public List<CastKnownForValueObject>? CastKnownFors { get; set; }
    }

    public class CastFilterParams : BaseFilterParam
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? Adult { get; set; }
        public long? Gender { get; set; }
        public long? ApiModelId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public List<CastImage>? CastImages { get; set; }
        public CastExternalId? CastExternalId { get; set; }
        public CastDetail? CastDetails { get; set; }
        public List<CastKnownForValueObject>? CastKnownFors { get; set; }
    }
    public class CastFilterResult : BaseFilter<CastDto, CastFilterParams>
    {

    }
}
