using WatchListMovies.Common.Domain.Repository;

namespace WatchListMovies.Domain.ContentImageAgg.Repository
{
    public interface IContentImageRepository : IBaseRepository<ContentImage>
    {
        Task AddIfNotExistAsync(ContentImage contentImage);
        Task AddRangeIfNotExistAsync(List<ContentImage> contentImages);
    }
}
