using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CollectionAgg
{
    public class CollectionRepository : BaseRepository<Domain.CollectionAgg.Collection>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddIfNotExistAsync(Domain.CollectionAgg.Collection collection)
        {

            var isExist = await Context.Collections.AnyAsync(m => m.ApiModelId == collection.ApiModelId);

            if (!isExist)
                await Context.Collections.AddAsync(collection);

        }

        public async Task<List<Domain.CollectionAgg.Collection>> GetAllAsync()
        {
            var result = await Context.Collections
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task BulkInsertIfNotExistAsync(List<Domain.CollectionAgg.Collection> collections)
        {
            var uniqueCollections = collections.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueCollections.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Collections
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newCollections = uniqueCollections.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newCollections.Any())
                await Context.BulkInsertAsync(newCollections);

        }

        public async Task BulkInsertOrUpdateAsync(List<Domain.CollectionAgg.Collection> collections)
        {
            await Context.BulkInsertOrUpdateAsync(collections, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Collections.CountAsync();
        }

        public async Task<List<Domain.CollectionAgg.Collection>> GetBatchAsync(int skip, int take)
        {
            return await Context.Collections
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
