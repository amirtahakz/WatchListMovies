using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetByFilter
{
    public class GetTvByFilterQueryHandler : IQueryHandler<GetTvByFilterQuery, TvFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetTvByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TvFilterResult> Handle(GetTvByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Tvs.OrderByDescending(d => d.Id).AsQueryable();

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

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new TvFilterResult()
            {
                Data = await result
                    .Skip(skip)
                    .Take(@params.Take)
                    .Select(tv => tv.MapFilterData())
                    .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
