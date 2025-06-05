using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Domain.CollectionAgg.Repository
{
    public interface ICollectionRepository : IBaseRepository<Collection>
    {
        Task AddIfNotExistAsync(Collection collection);
    }
}
