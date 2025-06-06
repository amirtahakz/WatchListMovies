using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.NetworkAgg.Repository
{
    public interface INetworkRepository : IBaseRepository<Network>
    {
        Task AddRangeIfNotExistAsync(List<Network> networks);
        Task<List<Domain.NetworkAgg.Network>> GetAllAsync();
    }
}
