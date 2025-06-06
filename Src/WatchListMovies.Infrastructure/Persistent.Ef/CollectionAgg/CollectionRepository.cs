using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CollectionAgg
{
    public class CollectionRepository : BaseRepository<Domain.CollectionAgg.Collection>, ICollectionRepository
    {
        public CollectionRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddIfNotExistAsync(Domain.CollectionAgg.Collection collection)
        {

            var isExist = await Context.Collections.AnyAsync(m => m.ApiModelId == collection.ApiModelId);

            if (!isExist)
                await Context.Collections.AddAsync(collection);

        }

        public async Task<List<Domain.CollectionAgg.Collection>> GetAllAsync()
        {
            var result = await Context.Collections
                .AsTracking()
                .ToListAsync();

            return result;
        }
    }
}
