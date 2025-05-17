using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Domain.UserAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.UserAgg
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}