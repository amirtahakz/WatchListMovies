using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.MovieAgg.Repository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<List<Movie>> GetAllAsync();
        Task<List<Movie>> GetAllAsNoTrackingAsync();
        Task<Movie> GetTrackingByImdbIdAsync(string imdbId);
        Task AddRangeIfNotExistAsync(List<Movie> movies);
        Task<bool> DeleteAllAsync();
    }
}
