using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Cast.DTOs;

namespace WatchListMovies.Query.Cast.GetByFilter
{
    public class GetCastByFilterQueryHandler : IQueryHandler<GetCastByFilterQuery, CastFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetCastByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CastFilterResult> Handle(GetCastByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Casts.OrderByDescending(d => d.Id).AsQueryable();

            if (@params.Adult != null)
                result = result.Where(r => r.Adult == @params.Adult);

            if (@params.ApiModelId != null)
                result = result.Where(r => r.ApiModelId == @params.ApiModelId);

            if (!string.IsNullOrWhiteSpace(@params.Name))
                result = result.Where(r => r.Name.Contains(@params.Name));

            if (!string.IsNullOrWhiteSpace(@params.OriginalName))
                result = result.Where(r => r.OriginalName.Contains(@params.OriginalName));

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);
            
            if (@params.ApiModelId != null)
                result = result.Where(r => r.ApiModelId == @params.ApiModelId);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CastFilterResult()
            {
                Data = await result
                .Skip(skip)
                .Take(@params.Take)
                .Select(movie => movie.MapFilterData())
                .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
