using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.MovieAgg.Repository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<List<Movie>> GetAllAsync();
        Task<List<Movie>> GetAllAsNoTrackingAsync();
        Task<bool> DeleteAllAsync();
    }
}
