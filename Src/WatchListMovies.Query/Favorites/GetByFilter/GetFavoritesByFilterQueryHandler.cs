using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Favorites;
using WatchListMovies.Query.Favorites.DTOs;

namespace WatchListMovies.Query.Favorites.GetByFilter
{
    public class GetFavoritesByFilterQueryHandler : IQueryHandler<GetFavoritesByFilterQuery, FavoriteFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetFavoritesByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<FavoriteFilterResult> Handle(GetFavoritesByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Favorites.OrderByDescending(d => d.Id).AsQueryable();

            if (@params.ListId != null)
                result = result.Where(r => r.ListId == @params.ListId);

            if (@params.FavoriteType != null)
                result = result.Where(r => r.FavoriteType == @params.FavoriteType);

            if (!string.IsNullOrWhiteSpace(@params.Note))
                result = result.Where(r => r.Note.Contains(@params.Note));

            if (@params.SubjectId != null)
                result = result.Where(r => r.SubjectGuid == @params.SubjectId);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new FavoriteFilterResult()
            {
                Data = await result
                    .Skip(skip)
                    .Take(@params.Take)
                    .Select(favorite => favorite.Map())
                    .ToListAsync(cancellationToken),
                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
