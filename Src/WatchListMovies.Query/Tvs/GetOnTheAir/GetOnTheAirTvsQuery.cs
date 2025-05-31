using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetOnTheAir
{
    public class GetOnTheAirTvsQuery : QueryFilter<GetOnTheAirTvsResult, GetOnTheAirTvsParams>
    {
        public GetOnTheAirTvsQuery(GetOnTheAirTvsParams filterParams) : base(filterParams)
        {
        }
    }
}
