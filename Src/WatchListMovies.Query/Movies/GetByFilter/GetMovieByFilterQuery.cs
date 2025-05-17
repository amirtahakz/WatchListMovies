using WatchListMovies.Common.Query;
using WatchListMovies.Query.Lists.GetByFilter;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetByFilter
{
    public class GetMovieByFilterQuery : QueryFilter<MovieFilterResult, MovieFilterParams>
    {
        public GetMovieByFilterQuery(MovieFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
