using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Favorites.DTOs;

namespace WatchListMovies.Query.Favorites.GetById
{
    public class GetFavoriteByIdQueryHandler : IQueryHandler<GetFavoriteByIdQuery, FavoriteDto?>
    {
        private readonly ApplicationDbContext _context;

        public GetFavoriteByIdQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FavoriteDto?> Handle(GetFavoriteByIdQuery request, CancellationToken cancellationToken)
        {
            var list = await _context.Favorites
                .FirstOrDefaultAsync(f => f.Id == request.FavoriteId, cancellationToken);
            if (list == null)
                return null;


            return list.Map();
        }
    }
}
