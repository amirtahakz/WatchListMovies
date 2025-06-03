using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.ContentCastAgg.Repository
{
    public interface IContentCastRepository : IBaseRepository<ContentCast>
    {
        Task AddIfNotExistAsync(ContentCast contentCast);
    }
}
