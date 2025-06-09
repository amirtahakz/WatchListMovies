using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Domain.SeasonAgg.Repository
{
    public interface ISeasonRepository : IBaseRepository<Season>
    {
        Task<List<Domain.SeasonAgg.Season>> GetAllAsync();
        Task AddRangeIfNotExistAsync(List<Domain.SeasonAgg.Season> seasons);
        Task<List<Domain.SeasonAgg.Season>> GetSeasonsByTvApiIdAsync(long? tvApiId);

        Task BulkInsertIfNotExistAsync(List<Season> seasons);
        Task BulkInsertOrUpdateAsync(List<Season> seasons);
        Task<long> GetCountAsync();

        Task<List<Season>> GetBatchAsync(int skip, int take);
    }
}
