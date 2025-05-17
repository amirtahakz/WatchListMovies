using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetByFilter
{
    public class GetMovieByFilterQueryHandler : IQueryHandler<GetMovieByFilterQuery, MovieFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetMovieByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieFilterResult> Handle(GetMovieByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;
            var result = _context.Movies.OrderByDescending(d => d.Id).AsQueryable();

            if (@params.Adult != null)
                result = result.Where(r => r.Adult == @params.Adult);

            if (@params.ApiModelId != null)
                result = result.Where(r => r.ApiModelId == @params.ApiModelId);

            if (!string.IsNullOrWhiteSpace(@params.Title))
                result = result.Where(r => r.Title.Contains(@params.Title));

            if (!string.IsNullOrWhiteSpace(@params.OriginalTitle))
                result = result.Where(r => r.OriginalTitle.Contains(@params.OriginalTitle));


            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new MovieFilterResult()
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
