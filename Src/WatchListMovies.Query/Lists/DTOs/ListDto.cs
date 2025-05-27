using WatchListMovies.Common.Query;
using WatchListMovies.Common.Query.Filter;
using WatchListMovies.Domain.ListAgg.Enums;
using WatchListMovies.Domain.UserAgg.Enums;

namespace WatchListMovies.Query.Lists.DTOs
{
    public class ListDto : BaseDto
    {
        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string Description { get; set; }
        public ListType ListType { get; set; }
    }

    public class ListFilterParams : BaseFilterParam
    {
        public Guid? UserId { get; set; }
        public string? Name { get; set; }
        public bool? IsPrivate { get; set; }
        public string? Description { get; set; }
        public ListType? ListType { get; set; }
    }
    public class ListFilterResult : BaseFilter<ListDto, ListFilterParams>
    {

    }
}
