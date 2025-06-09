using EFCore.BulkExtensions;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CompanyAgg
{
    public class CompanyRepository : BaseRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Company> companies)
        {

            foreach (var item in companies)
            {
                var isExist = await Context.Companies.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Companies.AddAsync(item);


            }

        }

        public async Task<List<Company>> GetAllAsync()
        {
            var result = await Context.Companies
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task BulkInsertIfNotExistAsync(List<Company> companies)
        {
            var uniqueCompanies = companies.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueCompanies.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Companies
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newCompanies = uniqueCompanies.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newCompanies.Any())
                await Context.BulkInsertAsync(newCompanies);

        }

        public async Task BulkInsertOrUpdateAsync(List<Company> companies)
        {
            await Context.BulkInsertOrUpdateAsync(companies, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Companies.CountAsync();
        }

        public async Task<List<Company>> GetBatchAsync(int skip, int take)
        {
            return await Context.Companies
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }
}
