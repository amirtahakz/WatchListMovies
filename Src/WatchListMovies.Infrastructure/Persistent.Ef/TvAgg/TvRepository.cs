using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Domain.TvAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.TvAgg
{
    public class TvRepository : BaseRepository<Tv>, ITvRepository
    {
        public TvRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Tv>> GetAllAsync()
        {
            var result = await Context.Tvs.AsTracking().ToListAsync();
            return result;
        }

        public async Task<List<Tv>> GetAllAsNoTrackingAsync()
        {
            var result = await Context.Tvs.AsNoTracking().ToListAsync();
            return result;
        }

        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                var genres = await Context.Tvs.ToListAsync();
                Context.Tvs.RemoveRange(genres);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task AddRangeIfNotExistAsync(List<Tv> tvs)
        {

            foreach (var item in tvs)
            {
                var isExist = await Context.Tvs.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Tvs.AddAsync(item);


            }

        }

        public async Task<Tv> GetTrackingByImdbIdAsync(long apiModelId)
        {
            var result = await Context.Tvs
                .AsTracking()
                .FirstOrDefaultAsync(x => x.ApiModelId == apiModelId);

            return result;
        }
    }
}
