using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.FavoriteAgg;

namespace WatchListMovies.Domain.ListAgg.Repository
{
    public interface IListRepository : IBaseRepository<List>
    {
    }
}
