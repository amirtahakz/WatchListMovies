using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentImageAgg;
using WatchListMovies.Domain.ContentImageAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ContentImageAgg
{
    public class ContentImageRepository : BaseRepository<ContentImage>, IContentImageRepository
    {
        public ContentImageRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task AddIfNotExistAsync(ContentImage contentImage)
        {
            var isExist = await Context.ContentImages.AnyAsync(v => v.FilePath == contentImage.FilePath);

            if (!isExist)
                await Context.ContentImages.AddAsync(contentImage);

        }

        public async Task AddRangeIfNotExistAsync(List<ContentImage> contentImages)
        {
            foreach (var contentImage in contentImages) 
            {
                var isExist = await Context.ContentImages.AnyAsync(v => v.FilePath == contentImage.FilePath);

                if (!isExist)
                    await Context.ContentImages.AddAsync(contentImage);
            }
        }
    }
}
