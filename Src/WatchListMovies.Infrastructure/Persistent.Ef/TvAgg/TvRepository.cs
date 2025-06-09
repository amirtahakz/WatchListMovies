using EFCore.BulkExtensions;
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

        public async Task BulkInsertIfNotExistAsync(List<Tv> tvs)
        {
            var uniqueTvs = tvs.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueTvs.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Tvs
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newTvs = uniqueTvs.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newTvs.Any())
                await Context.BulkInsertAsync(newTvs);

        }

        public async Task BulkInsertOrUpdateAsync(List<Tv> tvs)
        {
            await Context.BulkInsertOrUpdateAsync(tvs, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Tvs.CountAsync();
        }

        public async Task<List<Tv>> GetBatchAsync(int skip, int take)
        {
            return await Context.Tvs
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
