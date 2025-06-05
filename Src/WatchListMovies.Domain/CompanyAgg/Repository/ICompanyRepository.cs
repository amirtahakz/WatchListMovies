using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.ContentImageAgg;

namespace WatchListMovies.Domain.CompanyAgg.Repository
{
    public interface ICompanyRepository : IBaseRepository<Company>
    {
        Task AddRangeIfNotExistAsync(List<Company> companies);
    }
}
