using WatchListMovies.Common.Query;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.GetByFilter;

public class GetUserByFilterQuery : QueryFilter<UserFilterResult, UserFilterParams>
{
    public GetUserByFilterQuery(UserFilterParams filterParams) : base(filterParams)
    {
    }
}