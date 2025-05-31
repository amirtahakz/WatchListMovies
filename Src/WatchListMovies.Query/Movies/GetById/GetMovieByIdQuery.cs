using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetById
{
    public class GetMovieByIdQuery : IQuery<MovieDto?>
    {
        public GetMovieByIdQuery(Guid movieId)
        {
            MovieId = movieId;
        }

        public Guid MovieId { get; private set; }
    }
}
