using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Domain.GenreAgg.Repository
{
    public interface IGenreRepository : IBaseRepository<Genre>
    {
        Task<List<Genre>> GetAllAsync();
        Task<List<Genre>> GetAllAsNoTrackingAsync();
        Task<bool> DeleteAllAsync();

        Task AddRangeIfNotExistAsync(List<Genre> genres);
    }
}
