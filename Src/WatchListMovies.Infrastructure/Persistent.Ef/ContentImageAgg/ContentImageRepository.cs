using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentImageAgg;
using WatchListMovies.Domain.ContentImageAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ContentImageAgg
{
    public class ContentImageRepository : BaseRepository<ContentImage>, IContentImageRepository
    {
        public ContentImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddIfNotExistAsync(ContentImage contentImage)
        {
            var isExist = await Context.ContentImages.AnyAsync(v => v.FilePath == contentImage.FilePath);

            if (!isExist)
                await Context.ContentImages.AddAsync(contentImage);

        }

        public async Task AddRangeIfNotExistAsync(List<ContentImage> contentImages)
        {
            foreach (var contentImage in contentImages) 
            {
                var isExist = await Context.ContentImages.AnyAsync(v => v.FilePath == contentImage.FilePath);

                if (!isExist)
                    await Context.ContentImages.AddAsync(contentImage);
            }
        }

        public async Task BulkInsertIfNotExistAsync(List<ContentImage> contentImages)
        {
            var uniqueContentCasts = contentImages.GroupBy(p => p.FilePath).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueContentCasts.Select(d => d.FilePath).ToList();

            // گرفتن CreditId هایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.ContentImages
                .Where(m => apiModelIds.Contains(m.FilePath))
                .Select(m => m.FilePath)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newContentCasts = uniqueContentCasts.Where(dto => !existingApiIds.Contains(dto.FilePath)).ToList();

            // درج جدیدها
            if (newContentCasts.Any())
                await Context.BulkInsertAsync(newContentCasts);

        }

        public async Task BulkInsertOrUpdateAsync(List<ContentImage> contentImages)
        {
            await Context.BulkInsertOrUpdateAsync(contentImages, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.ContentImages.CountAsync();
        }

        public async Task<List<ContentImage>> GetBatchAsync(int skip, int take)
        {
            return await Context.ContentImages
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
