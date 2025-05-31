using WatchListMovies.Common.Query;
using WatchListMovies.Query.Lists.GetByFilter;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetByFilter
{
    public class GetMoviesByFilterQuery : QueryFilter<MovieFilterResult, MovieFilterParams>
    {
        public GetMoviesByFilterQuery(MovieFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
