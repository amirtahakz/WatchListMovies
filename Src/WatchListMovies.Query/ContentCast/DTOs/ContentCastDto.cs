using WatchListMovies.Common.Query;
using WatchListMovies.Domain.ContentCastAgg.Enums;

namespace WatchListMovies.Query.ContentCast.DTOs
{
    public class ContentCastDto : BaseDto
    {
        public long? ContentApiModelId { get; set; }
        public long? CastApiModelId { get; set; }
        public CreditTypeEnum? CreditType { get; set; }
        public ContentTypeEnum? ContentType { get; set; }
        public string? Character { get; set; }
        public string? Department { get; set; }
        public string? Job { get; set; }
        public string? CreditId { get; set; }
    }
}
