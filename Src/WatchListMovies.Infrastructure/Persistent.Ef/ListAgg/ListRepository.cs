using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.FavoriteAgg.Repository;
using WatchListMovies.Domain.FavoriteAgg;
using WatchListMovies.Domain.ListAgg;
using WatchListMovies.Infrastructure._Utilities;
using WatchListMovies.Domain.ListAgg.Repository;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ListAgg
{
    public class ListRepository : BaseRepository<List>, IListRepository
    {
        public ListRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
