using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.CountryAgg;

namespace WatchListMovies.Domain.LanguageAgg.Repository
{
    public interface ILanguageRepository : IBaseRepository<Language>
    {
        Task AddRangeIfNotExistAsync(List<Language> languages);
    }
}
