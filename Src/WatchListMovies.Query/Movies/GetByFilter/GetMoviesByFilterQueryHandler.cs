using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.GenreAgg;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies.GetByFilter
{
    public class GetMoviesByFilterQueryHandler : IQueryHandler<GetMoviesByFilterQuery, MovieFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetMoviesByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MovieFilterResult> Handle(GetMoviesByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var upcomingDate = DateTime.Now.AddDays(-25);

            var result = _context.Movies.Include(c => c.MovieDetails).AsQueryable();

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            if (@params.Adult != null)
                result = result.Where(r => r.Adult == @params.Adult);

            if (@params.ApiModelIds != null)
                result = result.Where(r => @params.ApiModelIds.Contains((long)r.ApiModelId));

            if (!string.IsNullOrWhiteSpace(@params.OriginalLanguage))
                result = result.Where(r => r.OriginalLanguage.Contains(@params.OriginalLanguage));

            if (!string.IsNullOrWhiteSpace(@params.OriginalTitle))
                result = result.Where(r => r.OriginalTitle.Contains(@params.OriginalTitle));

            if (!string.IsNullOrWhiteSpace(@params.Overview))
                result = result.Where(r => r.Overview.Contains(@params.Overview));

            if (@params.StartReleaseDate != null)
                result = result.Where(r => r.ReleaseDate >= @params.StartReleaseDate);

            if (@params.EndReleaseDate != null)
                result = result.Where(r => r.ReleaseDate <= @params.EndReleaseDate);

            if (!string.IsNullOrWhiteSpace(@params.Title))
                result = result.Where(r => r.Title.Contains(@params.Title));       

            // MovieDetails
            if (!string.IsNullOrWhiteSpace(@params.ImdbId))
                result = result.Where(r => r.MovieDetails.ImdbId.Contains(@params.ImdbId));


            switch (@params.MovieOrderByEnum)
            {
                case Domain.MovieAgg.Enums.MovieOrderByEnum.TopRated:
                    result = result.OrderBy(d => d.VoteAverage);
                    break;
                case Domain.MovieAgg.Enums.MovieOrderByEnum.ReleaseDate:
                    result = result.OrderBy(d => d.ReleaseDate);
                    break;
                default:
                    result = result.OrderByDescending(d => d.Id);
                    break;
            }

            var preGenreFilteredList = await result.ToListAsync();
            // فیلتر ژانر روی داده‌های در حافظه:
            if (@params.GenreIds != null && @params.GenreIds.Any())
            {
                var filterGenreIdsAsString = @params.GenreIds.Select(id => id.ToString()).ToList();

                preGenreFilteredList = preGenreFilteredList
                    .Where(movie => movie.GenreIds != null && movie.GenreIds.Any(genreId => filterGenreIdsAsString.Contains(genreId)))
                    .ToList();
            }

            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new MovieFilterResult()
            {
                Data = preGenreFilteredList
                .Skip(skip)
                .Take(@params.Take)
                .Select(movie => movie.Map())
                .ToList(),

                FilterParams = @params
            };

            model.GeneratePaging(preGenreFilteredList.Count(), @params.Take, @params.PageId);
            return model;
        }
    }
}
