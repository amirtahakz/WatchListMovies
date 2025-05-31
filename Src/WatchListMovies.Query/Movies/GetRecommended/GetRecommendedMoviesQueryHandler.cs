using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetRecommended
{
    public class GetRecommendedMoviesQueryHandler : IQueryHandler<GetRecommendedMoviesQuery, List<MovieDto>?>
    {
        private readonly ApplicationDbContext _context;

        public GetRecommendedMoviesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieDto>?> Handle(GetRecommendedMoviesQuery request, CancellationToken cancellationToken)
        {
            var movies = _context.Movies
                .Where(x => x.IsRecommendedByAdmin == true)
                .Take(request.Take)
                .OrderBy(c => c.VoteAverage);

            if (movies == null)
                throw new Exception("Movies Not Found.");


            return movies.ToList().Map();
        }
    }
}
