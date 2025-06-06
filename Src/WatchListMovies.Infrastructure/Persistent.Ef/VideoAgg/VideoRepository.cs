using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.SeasonAgg;
using WatchListMovies.Domain.VideoAgg;
using WatchListMovies.Domain.VideoAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.VideoAgg
{
    public class VideoRepository : BaseRepository<Domain.VideoAgg.Video>, IVideoRepository
    {
        public VideoRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Video> videos)
        {
            foreach (var item in videos)
            {
                var isExist = await Context.Videos.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Videos.AddAsync(item);
            }
        }

        public async Task<List<Video>> GetAllAsync()
        {
            var result = await Context.Videos
                .AsTracking()
                .ToListAsync();

            return result;
        }
    }
}
