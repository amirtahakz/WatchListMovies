using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.ContentImageAgg;

namespace WatchListMovies.Domain.VideoAgg.Repository
{
    public interface IVideoRepository : IBaseRepository<Domain.VideoAgg.Video>
    {
        Task<List<Domain.VideoAgg.Video>> GetAllAsync();
        Task AddRangeIfNotExistAsync(List<Domain.VideoAgg.Video> videos);

        Task BulkInsertIfNotExistAsync(List<Video> videos);
        Task BulkInsertOrUpdateAsync(List<Video> videos);
        Task<long> GetCountAsync();

        Task<List<Video>> GetBatchAsync(int skip, int take);
    }
}
