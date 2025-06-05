using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.ContentCasts;
using WatchListMovies.Query.ContentCasts.DTOs;

namespace WatchListMovies.Query.ContentCasts.GetByFilter
{
    public class GetContentCastsByFilterQueryHandler : IQueryHandler<GetContentCastsByFilterQuery, ContentCastFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetContentCastsByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ContentCastFilterResult> Handle(GetContentCastsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.ContentCasts.AsQueryable();

            if (@params.CreditType != null && @params.CreditType != 0)
                result = result.Where(r => r.CreditType == @params.CreditType);

            if (@params.ContentType != null && @params.ContentType != 0)
                result = result.Where(r => r.ContentType == @params.ContentType);

            if (@params.ContentApiModelId != null)
                result = result.Where(r => r.ContentApiModelId == @params.ContentApiModelId);

            if (@params.CastApiModelId != null)
                result = result.Where(r => r.CastApiModelId == @params.CastApiModelId);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new ContentCastFilterResult()
            {
                Data = await result
                .Skip(skip)
                .Take(@params.Take)
                .Select(contentCast => contentCast.Map())
                .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
