using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ContentCastAgg
{
    public class ContentCastRepository : BaseRepository<ContentCast>, IContentCastRepository
    {
        public ContentCastRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddIfNotExistAsync(ContentCast contentCast)
        {
            var isExist = await Context.ContentCasts.AnyAsync(v => v.CreditId == contentCast.CreditId);

            if (!isExist)
                await Context.ContentCasts.AddAsync(contentCast);
        }

        public async Task BulkInsertIfNotExistAsync(List<ContentCast> contentCasts)
        {
            var uniqueContentCasts = contentCasts.GroupBy(p => p.CreditId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueContentCasts.Select(d => d.CreditId).ToList();

            // گرفتن CreditId هایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.ContentCasts
                .Where(m => apiModelIds.Contains(m.CreditId))
                .Select(m => m.CreditId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newContentCasts = uniqueContentCasts.Where(dto => !existingApiIds.Contains(dto.CreditId)).ToList();

            // درج جدیدها
            if (newContentCasts.Any())
                await Context.BulkInsertAsync(newContentCasts);

        }

        public async Task BulkInsertOrUpdateAsync(List<ContentCast> contentCasts)
        {
            await Context.BulkInsertOrUpdateAsync(contentCasts, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.ContentCasts.CountAsync();
        }

        public async Task<List<ContentCast>> GetBatchAsync(int skip, int take)
        {
            return await Context.ContentCasts
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
