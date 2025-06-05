using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.GenreAgg;

namespace WatchListMovies.Domain.CountryAgg.Repository
{
    public interface ICountryRepository : IBaseRepository<Country>
    {
        Task AddRangeIfNotExistAsync(List<Country> countries);
    }
}
