using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetSimilar
{
    public class GetSimilarMoviesQuery : IQuery<List<MovieDto>?>
    {
        public Guid MovieId { get; set; }
        public int Take { get; set; } = 15;
    }
}
