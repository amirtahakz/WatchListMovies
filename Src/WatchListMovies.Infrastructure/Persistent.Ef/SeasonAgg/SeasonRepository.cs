using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.SeasonAgg;
using WatchListMovies.Domain.SeasonAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.SeasonAgg
{
    public class SeasonRepository : BaseRepository<Domain.SeasonAgg.Season>, ISeasonRepository
    {
        public SeasonRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Domain.SeasonAgg.Season>> GetAllAsync()
        {
            var result = await Context.Seasons
                .AsTracking()
                .ToListAsync();

            return result;
        }

        public async Task<List<Domain.SeasonAgg.Season>> GetSeasonsByTvApiIdAsync(long tvApiId)
        {
            var result = await Context.Seasons
                .AsNoTracking()
                .Where(x=>x.TvApiId == tvApiId)
                .OrderBy(x=>x.SeasonNumber)
                .ToListAsync();

            return result;
        }

        public async Task AddRangeIfNotExistAsync(List<Domain.SeasonAgg.Season> seasons)
        {
            foreach (var item in seasons)
            {
                var isExist = await Context.Seasons.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Seasons.AddAsync(item);
            }
        }
    }
}
