using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.MovieAgg.Repository
{
    public interface IMovieRepository : IBaseRepository<Movie>
    {
        Task<List<Movie>> GetAllAsync();
        Task<Movie> GetTrackingByImdbIdAsync(string imdbId);
        Task AddRangeIfNotExistAsync(List<Movie> movies);
        Task AddIfNotExistAsync(Movie movie);
        Task<bool> DeleteAllAsync();
        Task BulkInsertIfNotExistAsync(List<Movie> movies);
        Task BulkInsertOrUpdateAsync(List<Movie> movies);
        Task<long> GetCountAsync();

        Task<List<Movie>> GetBatchAsync(int skip, int take);
    }
}
