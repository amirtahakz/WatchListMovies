using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetRecommended
{
    public class GetRecommendedTvsQueryHandler : IQueryHandler<GetRecommendedTvsQuery, List<TvDto>?>
    {
        private readonly ApplicationDbContext _context;

        public GetRecommendedTvsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<List<TvDto>?> Handle(GetRecommendedTvsQuery request, CancellationToken cancellationToken)
        {
            var tvs = _context.Tvs
                .Where(x => x.IsRecommendedByAdmin == true)
                .Take(request.Take == 0 ? 20 : request.Take)
                .OrderBy(c => c.VoteAverage);

            if (tvs == null)
                throw new Exception("Tvs Not Found.");


            return tvs.ToList().Map();
        }
    }
}
