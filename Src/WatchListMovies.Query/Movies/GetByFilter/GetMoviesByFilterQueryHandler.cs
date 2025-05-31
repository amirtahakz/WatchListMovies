using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Linq;
using WatchListMovies.Common.Query;
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

            var result = _context.Movies.Include(c=>c.MovieDetails).AsQueryable();

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            if (@params.Adult != null)
                result = result.Where(r => r.Adult == @params.Adult);

            if (@params.ApiModelId != null)
                result = result.Where(r => r.ApiModelId == @params.ApiModelId);

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

            if (!string.IsNullOrWhiteSpace(@params.CollectionName))
                result = result.Where(r => r.MovieDetails.BelongsToCollection.Name.Contains(@params.CollectionName));

            if (@params.GenreIds != null)
                result = result.Where(r => r.MovieDetails.Genres.Any(genre=>@params.GenreIds.Contains((long)genre.ApiModelId)));

            if (@params.GenreNames != null)
                result = result.Where(r => r.MovieDetails.Genres.Any(genre => @params.GenreNames.Contains(genre.Name)));

            if (@params.CompanyNames != null)
                result = result.Where(r => r.MovieDetails.ProductionCompanies.Any(pc => @params.CompanyNames.Contains(pc.Name)));

            if (@params.CountryNames != null)
                result = result.Where(r => r.MovieDetails.Genres.Any(c => @params.CountryNames.Contains(c.Name)));

            if (@params.SpokenLanguageEnglishNames != null)
                result = result.Where(r => r.MovieDetails.SpokenLanguages.Any(sp => @params.SpokenLanguageEnglishNames.Contains(sp.Name)));


            switch (@params.MovieOrderByEnum)
            {
                case Domain.MovieAgg.Enums.MovieOrderByEnum.TopRated:
                    result.OrderBy(d=>d.VoteAverage);
                    break;
                case Domain.MovieAgg.Enums.MovieOrderByEnum.ReleaseDate:
                    result.OrderBy(d => d.ReleaseDate);
                    break;
                default:
                    result.OrderByDescending(d => d.Id);
                    break;
            }

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new MovieFilterResult()
            {
                Data = await result
                .Skip(skip)
                .Take(@params.Take)
                .Select(movie => movie.Map())
                .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
