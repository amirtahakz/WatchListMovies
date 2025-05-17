using WatchListMovies.Common.Query;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Lists.GetByFilter;

public class GetListByFilterQuery : QueryFilter<ListFilterResult, ListFilterParams>
{
    public GetListByFilterQuery(ListFilterParams filterParams) : base(filterParams)
    {
    }
}