using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.EpisodeAgg;
using WatchListMovies.Domain.EpisodeAgg.Repository;
using WatchListMovies.Domain.SeasonAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.EpisodeAgg
{
    public class EpisodeRepository : BaseRepository<Episode>, IEpisodeRepository
    {
        public EpisodeRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Episode> episodes)
        {
            foreach (var item in episodes)
            {
                var isExist = await Context.Episodes.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Episodes.AddAsync(item);


            }
        }

        public async Task<List<Episode>> GetAllAsync()
        {
            var result = await Context.Episodes
                .AsTracking()
                .ToListAsync();

            return result;
        }
    }
}
