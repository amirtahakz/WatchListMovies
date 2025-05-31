using Microsoft.EntityFrameworkCore;
using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Domain.TvAgg.Enums;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetOnTheAir
{
    public class GetOnTheAirTvsQueryHandler : IQueryHandler<GetOnTheAirTvsQuery, GetOnTheAirTvsResult>
    {
        private readonly ApplicationDbContext _context;

        public GetOnTheAirTvsQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GetOnTheAirTvsResult> Handle(GetOnTheAirTvsQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var today = DateTime.Today;
            var nextWeek = today.AddDays(7);

            var result = _context.Tvs
                .Include(c => c.TvDetail)
                .AsQueryable()
                .Where(tv => tv.TvDetail.EpisodeToAirs != null && tv.TvDetail.EpisodeToAirs
                .Any(e => e.EpisodeAirType == EpisodeAirType.NextEpisodeToAir &&
                     e.AirDate.HasValue &&
                     e.AirDate.Value.Date >= today &&
                     e.AirDate.Value.Date <= nextWeek));


            var skip = (@params.PageId - 1) * @params.Take;
            var model = new GetOnTheAirTvsResult()
            {
                Data = await result
                    .Skip(skip)
                    .Take(@params.Take)
                    .Select(tv => tv.Map())
                    .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
