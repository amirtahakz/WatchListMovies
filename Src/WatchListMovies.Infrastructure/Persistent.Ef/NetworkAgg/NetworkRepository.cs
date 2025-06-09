using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.ContentImageAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.NetworkAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.NetworkAgg
{
    public class NetworkRepository : BaseRepository<Domain.NetworkAgg.Network>, INetworkRepository
    {
        public NetworkRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Domain.NetworkAgg.Network> networks)
        {

            foreach (var item in networks)
            {
                var isExist = await Context.Networks.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Networks.AddAsync(item);


            }

        }

        public async Task<List<Domain.NetworkAgg.Network>> GetAllAsync()
        {
            var result = await Context.Networks
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task BulkInsertIfNotExistAsync(List<Domain.NetworkAgg.Network> networks)
        {
            var uniqueNetworks = networks.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueNetworks.Select(d => d.ApiModelId).ToList();

            // گرفتن CreditId هایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Networks
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newNetworks = uniqueNetworks.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newNetworks.Any())
                await Context.BulkInsertAsync(newNetworks);

        }

        public async Task BulkInsertOrUpdateAsync(List<Domain.NetworkAgg.Network> networks)
        {
            await Context.BulkInsertOrUpdateAsync(networks, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Networks.CountAsync();
        }

        public async Task<List<Domain.NetworkAgg.Network>> GetBatchAsync(int skip, int take)
        {
            return await Context.Networks
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }

    }
}
