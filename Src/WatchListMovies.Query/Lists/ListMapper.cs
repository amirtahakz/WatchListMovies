using WatchListMovies.Domain.ListAgg;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Lists
{
    public static class ListMapper
    {
        public static ListDto Map(this List list)
        {
            return new ListDto()
            {
                Id = list.Id,
                CreationDate = list.CreationDate,
                Name = list.Name,
                Description = list.Description,
                IsPrivate = list.IsPrivate,
                ListType = list.ListType,
                UserId = list.UserId,

            };
        }


        public static ListFilterData MapFilterData(this List list)
        {
            return new ListFilterData()
            {
                Id = list.Id,
                CreationDate = list.CreationDate,
                Name = list.Name,
                Description = list.Description,
                IsPrivate = list.IsPrivate,
                ListType = list.ListType,
                UserId = list.UserId,
            };
        }
    }
}
