using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetUpcoming
{
    public class GetUpcomingMoviesQuery : QueryFilter<UpcomingMoviesFilterResult, UpcomingMoviesFilterParams>
    {
        public GetUpcomingMoviesQuery(UpcomingMoviesFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
