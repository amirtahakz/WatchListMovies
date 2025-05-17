using WatchListMovies.Domain.FavoriteAgg;
using WatchListMovies.Domain.FavoriteAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.FavoriteAgg
{
    public class FavoriteRepository : BaseRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
