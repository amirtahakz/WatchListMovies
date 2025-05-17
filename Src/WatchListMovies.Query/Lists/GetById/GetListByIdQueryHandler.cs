using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Lists.GetById;

public class GetListByIdQueryHandler : IQueryHandler<GetListByIdQuery, ListDto?>
{
    private readonly ApplicationDbContext _context;

    public GetListByIdQueryHandler(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<ListDto?> Handle(GetListByIdQuery request, CancellationToken cancellationToken)
    {
        var list = await _context.Lists
            .FirstOrDefaultAsync(f => f.Id == request.ListId, cancellationToken);
        if (list == null)
            return null;


        return list.Map();
    }
}