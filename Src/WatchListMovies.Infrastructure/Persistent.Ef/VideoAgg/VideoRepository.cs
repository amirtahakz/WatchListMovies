using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.VideoAgg;
using WatchListMovies.Domain.VideoAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.VideoAgg
{
    public class VideoRepository : BaseRepository<Domain.VideoAgg.Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Video> videos)
        {
            foreach (var item in videos)
            {
                var isExist = await Context.Videos.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Videos.AddAsync(item);
            }
        }

        public async Task<List<Video>> GetAllAsync()
        {
            var result = await Context.Videos
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task BulkInsertIfNotExistAsync(List<Video> videos)
        {
            var uniqueVideos = videos.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueVideos.Select(d => d.ApiModelId).ToList();

            // گرفتن CreditId هایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Videos
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newContentCasts = uniqueVideos.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newContentCasts.Any())
                await Context.BulkInsertAsync(newContentCasts);

        }

        public async Task BulkInsertOrUpdateAsync(List<Video> videos)
        {
            await Context.BulkInsertOrUpdateAsync(videos, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Videos.CountAsync();
        }

        public async Task<List<Video>> GetBatchAsync(int skip, int take)
        {
            return await Context.Videos
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
