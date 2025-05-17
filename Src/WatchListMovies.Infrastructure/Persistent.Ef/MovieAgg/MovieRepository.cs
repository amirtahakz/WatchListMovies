using WatchListMovies.Infrastructure._Utilities;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.MovieAgg.Repository;
using Microsoft.EntityFrameworkCore;

namespace WatchListMovies.Infrastructure.Persistent.Ef.MovieAgg
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var result = await Context.Movies
                .AsTracking()
                .ToListAsync();
            return result;
        }

        public async Task<List<Movie>> GetAllAsNoTrackingAsync()
        {
            var result = await Context.Movies.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                var genres = await Context.Movies.AsTracking().ToListAsync();
                Context.Movies.RemoveRange(genres);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
