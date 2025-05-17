using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Domain.TvAgg.Repository
{
    public interface ITvRepository : IBaseRepository<Tv>
    {
        Task<List<Tv>> GetAllAsync();
        Task<List<Tv>> GetAllAsNoTrackingAsync();
        Task<bool> DeleteAllAsync();

    }
}
