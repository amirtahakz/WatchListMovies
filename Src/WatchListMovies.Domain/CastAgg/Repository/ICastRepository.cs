using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.CastAgg.Repository
{
    public interface ICastRepository : IBaseRepository<Cast>
    {
        Task<List<Cast>> GetAllAsync();
        Task<List<Cast>> GetAllAsNoTrackingAsync();
        Task<bool> DeleteAllAsync();
        Task AddRangeIfNotExistAsync(List<Cast> casts);
        Task<Cast> GetTrackingByApiModelIdAsync(long apiModelId);

    }
}
