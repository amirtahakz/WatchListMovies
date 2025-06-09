using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Domain.EpisodeAgg.Repository
{
    public interface IEpisodeRepository : IBaseRepository<Episode>
    {
        Task<List<Domain.EpisodeAgg.Episode>> GetAllAsync();
        Task AddRangeIfNotExistAsync(List<Domain.EpisodeAgg.Episode> episodes);

        Task BulkInsertIfNotExistAsync(List<Episode> episodes);
        Task BulkInsertOrUpdateAsync(List<Episode> episodes);
        Task<long> GetCountAsync();

        Task<List<Episode>> GetBatchAsync(int skip, int take);
    }
}
