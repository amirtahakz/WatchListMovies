using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.NetworkAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.Network
{
    public class NetworkRepository : BaseRepository<Domain.NetworkAgg.Network>, INetworkRepository
    {
        public NetworkRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddRangeIfNotExistAsync(List<Domain.NetworkAgg.Network> networks)
        {

            foreach (var item in networks)
            {
                var isExist = await Context.Networks.AnyAsync(m => m.ApiModelId == item.ApiModelId);

                if (!isExist)
                    await Context.Networks.AddAsync(item);


            }

        }

        public async Task<List<Domain.NetworkAgg.Network>> GetAllAsync()
        {
            var result = await Context.Networks
                .AsTracking()
                .ToListAsync();

            return result;
        }
    }
}
