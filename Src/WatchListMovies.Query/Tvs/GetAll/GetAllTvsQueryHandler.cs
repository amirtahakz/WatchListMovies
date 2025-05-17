using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetAll;

public class GetAllTvsQueryHandler : IQueryHandler<GetAllTvsQuery, List<TvDto>?>
{
    private readonly ApplicationDbContext _context;
    private readonly IMapper _mapper;

    public GetAllTvsQueryHandler(ApplicationDbContext context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }

    public async Task<List<TvDto>?> Handle(GetAllTvsQuery request, CancellationToken cancellationToken)
    {
        var tvs = await _context.Tvs.ToListAsync();

        if (tvs == null)
            return null;


        return _mapper.Map<List<TvDto>>(tvs);
    }
}