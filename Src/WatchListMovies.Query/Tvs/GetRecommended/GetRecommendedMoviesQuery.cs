using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetRecommended
{
    public class GetRecommendedTvsQuery : IQuery<List<TvDto>?>
    {
        public int Take { get; set; } = 20;
    }
}
