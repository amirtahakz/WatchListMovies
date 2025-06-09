using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.ContentImageAgg;

namespace WatchListMovies.Domain.NetworkAgg.Repository
{
    public interface INetworkRepository : IBaseRepository<Network>
    {
        Task AddRangeIfNotExistAsync(List<Network> networks);
        Task<List<Domain.NetworkAgg.Network>> GetAllAsync();
        Task BulkInsertIfNotExistAsync(List<Network> networks);
        Task BulkInsertOrUpdateAsync(List<Network> networks);
        Task<long> GetCountAsync();

        Task<List<Network>> GetBatchAsync(int skip, int take);
    }
}
