using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Domain.CountryAgg.Repository;
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
    }
}
