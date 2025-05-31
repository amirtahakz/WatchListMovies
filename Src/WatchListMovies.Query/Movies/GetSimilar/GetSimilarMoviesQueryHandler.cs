using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetSimilar
{
    public class GetSimilarMoviesQueryHandler : IQueryHandler<GetSimilarMoviesQuery, List<MovieDto>?>
    {
        private readonly ApplicationDbContext _context;

        public GetSimilarMoviesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<MovieDto>?> Handle(GetSimilarMoviesQuery request, CancellationToken cancellationToken)
        {
            var movie = await _context.Movies.FirstOrDefaultAsync(f => f.Id == request.MovieId, cancellationToken);
            if (movie == null)
                throw new Exception("Movie Not Found.");

            var similarMovies = _context.Movies
                .AsEnumerable()
                .Where(m => m.GenreIds.Intersect(movie.GenreIds).Any())
                .Take(request.Take)
                .OrderBy(c=>c.VoteAverage);

            return similarMovies.ToList().Map();
        }
    }
}
