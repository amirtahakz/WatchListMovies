using WatchListMovies.Common.Query;
using WatchListMovies.Domain.ContentCastAgg.Enums;

namespace WatchListMovies.Query.ContentCast.DTOs
{
    public class ContentCastFilterParams : BaseFilterParam
    {
        public long? ContentApiModelId { get; set; }
        public long? CastApiModelId { get; set; }
        public CreditTypeEnum? CreditType { get; set; }
        public ContentTypeEnum? ContentType { get; set; }
    }
}
