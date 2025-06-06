using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.EpisodeAgg.Repository
{
    public interface IEpisodeRepository : IBaseRepository<Episode>
    {
        Task<List<Domain.EpisodeAgg.Episode>> GetAllAsync();
        Task AddRangeIfNotExistAsync(List<Domain.EpisodeAgg.Episode> episodes);
    }
}
