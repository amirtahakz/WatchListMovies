using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Domain.CountryAgg.Repository;
using WatchListMovies.Domain.LanguageAgg;
using WatchListMovies.Domain.LanguageAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.LanguageAgg
{
    public class LanguageRepository : BaseRepository<Language>, ILanguageRepository
    {
        public LanguageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Language> languages)
        {

            foreach (var item in languages)
            {
                var isExist = await Context.Languages.AnyAsync(m => m.Iso6391 == item.Iso6391);

                if (!isExist)
                    await Context.Languages.AddAsync(item);


            }

        }
    }
}
