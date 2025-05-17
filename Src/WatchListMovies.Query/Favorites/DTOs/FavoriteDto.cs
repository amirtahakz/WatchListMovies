using WatchListMovies.Common.Query;
using WatchListMovies.Common.Query.Filter;
using WatchListMovies.Domain.FavoriteAgg.Enums;

namespace WatchListMovies.Query.Favorites.DTOs
{
    public class FavoriteDto : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ListId { get; set; }
        public string Note { get; set; }
        public FavoriteType FavoriteType { get; set; }
    }

    public class FavoriteFilterData : BaseDto
    {
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ListId { get; set; }
        public string Note { get; set; }
        public FavoriteType FavoriteType { get; set; }
    }

    public class FavoriteFilterParams : BaseFilterParam
    {
        public Guid? UserId { get; set; }
        public Guid? SubjectId { get; set; }
        public Guid? ListId { get; set; }
        public string? Note { get; set; }
        public FavoriteType? FavoriteType { get; set; }
    }
    public class FavoriteFilterResult : BaseFilter<FavoriteFilterData, FavoriteFilterParams>
    {

    }
}
