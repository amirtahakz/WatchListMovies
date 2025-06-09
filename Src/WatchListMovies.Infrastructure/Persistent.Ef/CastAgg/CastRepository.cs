using EFCore.BulkExtensions;
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

        public async Task BulkInsertIfNotExistAsync(List<Cast> casts)
        {
            var uniqueCasts = casts.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueCasts.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Casts
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newCasts = uniqueCasts.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newCasts.Any())
                await Context.BulkInsertAsync(newCasts);

        }

        public async Task BulkInsertOrUpdateAsync(List<Cast> casts)
        {
            await Context.BulkInsertOrUpdateAsync(casts, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Casts.CountAsync();
        }

        public async Task<List<Cast>> GetBatchAsync(int skip, int take)
        {
            return await Context.Casts
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
