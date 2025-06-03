using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.ContentCastAgg.Enums;

namespace WatchListMovies.Domain.ContentCastAgg
{
    public class ContentCast : BaseEntity
    {
        public ContentCast()
        {
            
        }

        public ContentCast(
            long? contentApiModelId,
            long? castApiModelId,
            CreditTypeEnum? creditType,
            ContentTypeEnum? contentType,
            string? character,
            string? department,
            string? job,
            string? creditId)
        {
            ContentApiModelId = contentApiModelId;
            CastApiModelId = castApiModelId;
            CreditType = creditType;
            ContentType = contentType;
            Character = character;
            Department = department;
            Job = job;
            CreditId = creditId;
        }

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
