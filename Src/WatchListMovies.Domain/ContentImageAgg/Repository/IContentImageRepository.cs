using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.ContentCastAgg;

namespace WatchListMovies.Domain.ContentImageAgg.Repository
{
    public interface IContentImageRepository : IBaseRepository<ContentImage>
    {
        Task AddIfNotExistAsync(ContentImage contentImage);
        Task AddRangeIfNotExistAsync(List<ContentImage> contentImages);

        Task BulkInsertIfNotExistAsync(List<ContentImage> contentImages);
        Task BulkInsertOrUpdateAsync(List<ContentImage> contentImages);
        Task<long> GetCountAsync();

        Task<List<ContentImage>> GetBatchAsync(int skip, int take);
    }
}
