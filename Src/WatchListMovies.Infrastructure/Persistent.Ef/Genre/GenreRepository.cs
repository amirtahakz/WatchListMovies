using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.Genre
{
    public class GenreRepository : BaseRepository<Domain.GenreAgg.Genre>, IGenreRepository
    {
        public GenreRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Domain.GenreAgg.Genre>> GetAllAsync()
        {
            var result = await Context.Genres.AsTracking().ToListAsync();
            return result;
        }

        public async Task<List<Domain.GenreAgg.Genre>> GetAllAsNoTrackingAsync()
        {
            var result = await Context.Genres.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                var genres = await Context.Genres.ToListAsync();
                Context.Genres.RemoveRange(genres);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
    }
}
