using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CastAgg
{
    public class CastRepository : BaseRepository<Cast>, ICastRepository
    {
        public CastRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Cast>> GetAllAsync()
        {
            var result = await Context.Casts.AsTracking().ToListAsync();
            return result;
        }

        public async Task<List<Cast>> GetAllAsNoTrackingAsync()
        {
            var result = await Context.Casts.AsNoTracking().ToListAsync();
            return result;
        }


        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                var genres = await Context.Casts.ToListAsync();
                Context.Casts.RemoveRange(genres);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task AddRangeIfNotExistAsync(List<Cast> casts)
        {

            foreach (var item in casts)
            {
                var isExist = await Context.Casts.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Casts.AddAsync(item);


            }

        }

        public async Task<Cast> GetTrackingByApiModelIdAsync(long apiModelId)
        {
            var result = await Context.Casts
                .AsTracking()
                .FirstOrDefaultAsync(x => x.ApiModelId == apiModelId);

            return result;
        }
    }
}
