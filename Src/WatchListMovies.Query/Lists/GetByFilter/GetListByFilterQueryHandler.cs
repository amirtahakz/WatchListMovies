using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Lists.GetByFilter;

public class GetListByFilterQueryHandler : IQueryHandler<GetListByFilterQuery, ListFilterResult>
{
    private readonly ApplicationDbContext _context;

    public GetListByFilterQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ListFilterResult> Handle(GetListByFilterQuery request, CancellationToken cancellationToken)
    {
        var @params = request.FilterParams;
        var result = _context.Lists.OrderByDescending(d => d.Id).AsQueryable();

        if (@params.IsPrivate != null)
            result = result.Where(r => r.IsPrivate == @params.IsPrivate);

        if (@params.ListType != null)
            result = result.Where(r => r.ListType == @params.ListType);

        if (!string.IsNullOrWhiteSpace(@params.Name))
            result = result.Where(r => r.Name.Contains(@params.Name));

        if (!string.IsNullOrWhiteSpace(@params.Description))
            result = result.Where(r => r.Description.Contains(@params.Description));

        if (@params.UserId != null)
            result = result.Where(r => r.UserId == @params.UserId);

        var skip = (@params.PageId - 1) * @params.Take;
        var model = new ListFilterResult()
        {
            Data = await result.Skip(skip).Take(@params.Take)
                .Select(list => list.MapFilterData()).ToListAsync(cancellationToken),
            FilterParams = @params
        };

        model.GeneratePaging(result, @params.Take, @params.PageId);
        return model;
    }
}