using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.SeasonAgg;
using WatchListMovies.Domain.SeasonAgg.Repository;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.SeasonAgg
{
    public class SeasonRepository : BaseRepository<Domain.SeasonAgg.Season>, ISeasonRepository
    {
        public SeasonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Domain.SeasonAgg.Season>> GetAllAsync()
        {
            var result = await Context.Seasons
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task<List<Domain.SeasonAgg.Season>> GetSeasonsByTvApiIdAsync(long? tvApiId)
        {
            var result = await Context.Seasons
                .AsNoTracking()
                .Where(x=>x.TvApiId == tvApiId)
                .OrderBy(x=>x.SeasonNumber)
                .ToListAsync();

            return result;
        }

        public async Task AddRangeIfNotExistAsync(List<Domain.SeasonAgg.Season> seasons)
        {
            foreach (var item in seasons)
            {
                var isExist = await Context.Seasons.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Seasons.AddAsync(item);
            }
        }

        public async Task BulkInsertIfNotExistAsync(List<Season> seasons)
        {
            var uniqueSeasons = seasons.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueSeasons.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Seasons
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newSeasons = uniqueSeasons.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newSeasons.Any())
                await Context.BulkInsertAsync(newSeasons);

        }

        public async Task BulkInsertOrUpdateAsync(List<Season> seasons)
        {
            await Context.BulkInsertOrUpdateAsync(seasons, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Seasons.CountAsync();
        }

        public async Task<List<Season>> GetBatchAsync(int skip, int take)
        {
            return await Context.Seasons
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }

    }
}
