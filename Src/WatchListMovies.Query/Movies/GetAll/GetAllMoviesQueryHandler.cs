using AutoMapper;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetAll
{
    public class GetAllMoviesQueryHandler : IQueryHandler<GetAllMoviesQuery, List<MovieDto>?>
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public GetAllMoviesQueryHandler(ApplicationDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<List<MovieDto>?> Handle(GetAllMoviesQuery request, CancellationToken cancellationToken)
        {
            var tvs = await _context.Tvs.ToListAsync();

            if (tvs == null)
                return null;


            return _mapper.Map<List<MovieDto>>(tvs);
        }
    }
}
