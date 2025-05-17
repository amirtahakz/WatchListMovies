using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Genre.DTOs;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetByFilter;

namespace WatchListMovies.Query.Genre.GetByFilter
{
    public class GetGenreByFilterQueryHandler : IQueryHandler<GetGenreByFilterQuery, GenreFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetGenreByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GenreFilterResult> Handle(GetGenreByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Genres.OrderByDescending(d => d.Id).AsQueryable();

            if (@params.GenreType != null)
                result = result.Where(r => r.GenreType == @params.GenreType);

            if (@params.ApiModelId != null)
                result = result.Where(r => r.ApiModelId == @params.ApiModelId);

            if (!string.IsNullOrWhiteSpace(@params.Name))
                result = result.Where(r => r.Name.Contains(@params.Name));

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new GenreFilterResult()
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
