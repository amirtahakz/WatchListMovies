using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Domain.CountryAgg.Repository;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CountryAgg
{
    public class CountryRepository : BaseRepository<Country>, ICountryRepository
    {
        public CountryRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Country> countries)
        {

            foreach (var item in countries)
            {
                var isExist = await Context.Countries.AnyAsync(m => m.Iso31661 == item.Iso31661);

                if (!isExist)
                    await Context.Countries.AddAsync(item);


            }

        }
    }
}
