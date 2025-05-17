using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetAllAsNoTracking;

public class GetAllAsNoTrackingQueryHandler : IQueryHandler<GetAllAsNoTrackingQuery, List<TvDto>?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllAsNoTrackingQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TvDto>?> Handle(GetAllAsNoTrackingQuery request, CancellationToken cancellationToken)
    {
        var tvs = await _context.Tvs.AsNoTracking().ToListAsync();

        if (tvs == null)
            return null;


        return _mapper.Map<List<TvDto>>(tvs);
    }
}