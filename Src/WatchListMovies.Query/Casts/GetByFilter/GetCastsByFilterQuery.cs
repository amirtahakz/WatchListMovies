using WatchListMovies.Common.Query;
using WatchListMovies.Query.Casts.DTOs;

namespace WatchListMovies.Query.Casts.GetByFilter
{
    public class GetCastsByFilterQuery : QueryFilter<CastFilterResult, CastFilterParams>
    {
        public GetCastsByFilterQuery(CastFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
