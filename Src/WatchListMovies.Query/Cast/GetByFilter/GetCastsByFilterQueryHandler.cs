using Microsoft.EntityFrameworkCore;
using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Cast.DTOs;

namespace WatchListMovies.Query.Cast.GetByFilter
{
    public class GetCastsByFilterQueryHandler : IQueryHandler<GetCastsByFilterQuery, CastFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetCastsByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CastFilterResult> Handle(GetCastsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Casts.OrderByDescending(d => d.Id).AsQueryable();

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            if (@params.Gender != null)
                result = result.Where(r => r.Gender == @params.Gender);

            if (@params.ApiModelIds != null)
                result = result.Where(r => @params.ApiModelIds.Contains((long)r.ApiModelId));

            if (!string.IsNullOrWhiteSpace(@params.Name))
                result = result.Where(r => r.Name.Contains(@params.Name));

            if (!string.IsNullOrWhiteSpace(@params.OriginalName))
                result = result.Where(r => r.OriginalName.Contains(@params.OriginalName));     

            if (@params.IsRecommendedByAdmin != null)
                result = result.Where(r => r.IsRecommendedByAdmin == @params.IsRecommendedByAdmin);

            if (@params.StartBirthday != null)
                result = result.Where(r => r.CastDetails.Birthday >= @params.StartBirthday);

            if (@params.EndBirthday != null)
                result = result.Where(r => r.CastDetails.Birthday <= @params.EndBirthday);

            if (@params.StartDeathday != null)
                result = result.Where(r => r.CastDetails.Deathday >= @params.StartDeathday);

            if (@params.EndDeathday != null)
                result = result.Where(r => r.CastDetails.Deathday <= @params.EndDeathday);

            if (!string.IsNullOrWhiteSpace(@params.ImdbId))
                result = result.Where(r => r.CastDetails.ImdbId.Contains(@params.ImdbId));

            if (@params.CastAlsoKnownAss != null)
                result = result.Where(r => r.CastDetails.CastAlsoKnownAss.Any(c => @params.CastAlsoKnownAss.Contains(c)));

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CastFilterResult()
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
