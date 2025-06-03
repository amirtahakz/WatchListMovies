using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ContentCastAgg
{
    public class ContentCastRepository : BaseRepository<ContentCast>, IContentCastRepository
    {
        public ContentCastRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddIfNotExistAsync(ContentCast contentCast)
        {
            var isExist = await Context.ContentCasts.AnyAsync(v => v.CreditId == contentCast.CreditId);

            if (!isExist) 
            {
                await Context.ContentCasts.AddAsync(contentCast);
            }
        }
    }
}
