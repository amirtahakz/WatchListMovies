using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetById
{
    public class GetMovieByIdQueryHandler : IQueryHandler<GetMovieByIdQuery, MovieDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetMovieByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieDto?> Handle(GetMovieByIdQuery request, CancellationToken cancellationToken)
        {
            var result = await _context.Movies.FirstOrDefaultAsync(f => f.Id == request.MovieId, cancellationToken);
            if (result == null)
                throw new Exception("Movie Not Found.");


            return result.Map();
        }
    }
}
