using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Domain.TvAgg.Repository
{
    public interface ITvRepository : IBaseRepository<Tv>
    {
        Task<List<Tv>> GetAllAsync();
        Task<List<Tv>> GetAllAsNoTrackingAsync();
        Task<bool> DeleteAllAsync();
        Task AddRangeIfNotExistAsync(List<Tv> tvs);
        Task<Tv> GetTrackingByImdbIdAsync(long apiModelId);

        Task BulkInsertIfNotExistAsync(List<Tv> movies);
        Task BulkInsertOrUpdateAsync(List<Tv> movies);
        Task<long> GetCountAsync();

        Task<List<Tv>> GetBatchAsync(int skip, int take);

    }
}
