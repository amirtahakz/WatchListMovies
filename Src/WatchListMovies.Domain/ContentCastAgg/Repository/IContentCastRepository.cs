using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Domain.ContentCastAgg.Repository
{
    public interface IContentCastRepository : IBaseRepository<ContentCast>
    {
        Task AddIfNotExistAsync(ContentCast contentCast);

        Task BulkInsertIfNotExistAsync(List<ContentCast> contentCasts);
        Task BulkInsertOrUpdateAsync(List<ContentCast> contentCasts);
        Task<long> GetCountAsync();

        Task<List<ContentCast>> GetBatchAsync(int skip, int take);
    }
}
