using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Domain.CastAgg.Repository
{
    public interface ICastRepository : IBaseRepository<Cast>
    {
        Task<List<Cast>> GetAllAsync();
        Task<List<Cast>> GetAllAsNoTrackingAsync();
        Task<bool> DeleteAllAsync();
        Task AddRangeIfNotExistAsync(List<Cast> casts);
        Task<Cast> GetTrackingByApiModelIdAsync(long apiModelId);

        Task BulkInsertIfNotExistAsync(List<Cast> casts);
        Task BulkInsertOrUpdateAsync(List<Cast> casts);
        Task<long> GetCountAsync();

        Task<List<Cast>> GetBatchAsync(int skip, int take);

    }
}
