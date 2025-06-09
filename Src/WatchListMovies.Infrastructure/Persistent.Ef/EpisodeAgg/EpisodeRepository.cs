using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.EpisodeAgg;
using WatchListMovies.Domain.EpisodeAgg.Repository;
using WatchListMovies.Domain.SeasonAgg;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.EpisodeAgg
{
    public class EpisodeRepository : BaseRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Episode> episodes)
        {
            foreach (var item in episodes)
            {
                var isExist = await Context.Episodes.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Episodes.AddAsync(item);


            }
        }

        public async Task<List<Episode>> GetAllAsync()
        {
            var result = await Context.Episodes
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task BulkInsertIfNotExistAsync(List<Episode> episodes)
        {
            var uniqueEpisodes = episodes.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueEpisodes.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Episodes
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newEpisodes = uniqueEpisodes.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newEpisodes.Any())
                await Context.BulkInsertAsync(newEpisodes);

        }

        public async Task BulkInsertOrUpdateAsync(List<Episode> episodes)
        {
            await Context.BulkInsertOrUpdateAsync(episodes, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Episodes.CountAsync();
        }

        public async Task<List<Episode>> GetBatchAsync(int skip, int take)
        {
            return await Context.Episodes
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
