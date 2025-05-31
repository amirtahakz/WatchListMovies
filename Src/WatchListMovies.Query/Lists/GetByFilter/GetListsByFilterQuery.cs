using WatchListMovies.Common.Query;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Lists.GetByFilter;

public class GetListsByFilterQuery : QueryFilter<ListFilterResult, ListFilterParams>
{
    public GetListsByFilterQuery(ListFilterParams filterParams) : base(filterParams)
    {
    }
}