using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.VideoAgg.Repository
{
    public interface IVideoRepository : IBaseRepository<Domain.VideoAgg.Video>
    {
        Task<List<Domain.VideoAgg.Video>> GetAllAsync();
        Task AddRangeIfNotExistAsync(List<Domain.VideoAgg.Video> videos);
    }
}
