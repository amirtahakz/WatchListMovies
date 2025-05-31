using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetUpcoming
{
    public class GetUpcomingMoviesQueryHandler : IQueryHandler<GetUpcomingMoviesQuery, UpcomingMoviesFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetUpcomingMoviesQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UpcomingMoviesFilterResult> Handle(GetUpcomingMoviesQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var upcomingDate = DateTime.Now.AddDays(-25);

            var result = _context.Movies
                .Include(c => c.MovieDetails)
                .AsQueryable()
                .Where(r => r.ReleaseDate >= upcomingDate)
                .OrderBy(d => d.ReleaseDate);


            var skip = (@params.PageId - 1) * @params.Take;
            var model = new UpcomingMoviesFilterResult()
            {
                Data = await result
                .Skip(skip)
                .Take(@params.Take)
                .Select(movie => movie.Map())
                .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
