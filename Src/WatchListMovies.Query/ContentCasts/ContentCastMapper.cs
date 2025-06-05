using WatchListMovies.Query.ContentCasts.DTOs;

namespace WatchListMovies.Query.ContentCasts
{
    public static class ContentCastMapper
    {
        public static ContentCastDto Map(this Domain.ContentCastAgg.ContentCast contentCast)
        {
            return new ContentCastDto()
            {
                Id = contentCast.Id,
                CreationDate = contentCast.CreationDate,
                CastApiModelId = contentCast.CastApiModelId,
                ContentApiModelId = contentCast.ContentApiModelId,
                ContentType = contentCast.ContentType,
                CreditType = contentCast.CreditType,
                Character = contentCast.Character,
                CreditId = contentCast.CreditId,
                Department = contentCast.Department,
                Job = contentCast.Job
            };
        }
    }
}
