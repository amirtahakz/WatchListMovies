using WatchListMovies.Common.Query;
using WatchListMovies.Query.Seasons.DTOs;

namespace WatchListMovies.Query.Seasons.GetByFilter
{
    public class GetSeasonsByFilterQuery : QueryFilter<SeasonFilterResult, SeasonFilterParams>
    {
        public GetSeasonsByFilterQuery(SeasonFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
