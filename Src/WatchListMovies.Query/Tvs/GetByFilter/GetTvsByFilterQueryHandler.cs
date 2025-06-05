using Microsoft.EntityFrameworkCore;
using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.GenreAgg;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetByFilter
{
    public class GetTvsByFilterQueryHandler : IQueryHandler<GetTvsByFilterQuery, TvFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetTvsByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<TvFilterResult> Handle(GetTvsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var upcomingDate = DateTime.Now.AddDays(-25);

            var result = _context.Tvs.Include(c => c.TvDetail).AsQueryable();

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            if (@params.Adult != null)
                result = result.Where(r => r.Adult == @params.Adult);

            if (@params.ApiModelIds != null)
                result = result.Where(r => @params.ApiModelIds.Contains((long)r.ApiModelId));

            if (!string.IsNullOrWhiteSpace(@params.OriginalLanguage))
                result = result.Where(r => r.OriginalLanguage.Contains(@params.OriginalLanguage));

            if (!string.IsNullOrWhiteSpace(@params.OriginalName))
                result = result.Where(r => r.OriginalName.Contains(@params.OriginalName));

            if (!string.IsNullOrWhiteSpace(@params.Overview))
                result = result.Where(r => r.Overview.Contains(@params.Overview));

            if (@params.StartFirstAirDate != null)
                result = result.Where(r => r.FirstAirDate >= @params.StartFirstAirDate);

            if (@params.EndFirstAirDate != null)
                result = result.Where(r => r.FirstAirDate <= @params.EndFirstAirDate);

            if (@params.StartVoteAverage != null)
                result = result.Where(r => r.VoteAverage >= @params.StartVoteAverage);

            if (@params.EndVoteAverage != null)
                result = result.Where(r => r.VoteAverage <= @params.EndVoteAverage);

            if (@params.InProduction != null)
                result = result.Where(r => r.TvDetail.InProduction == @params.InProduction);

            if (!string.IsNullOrWhiteSpace(@params.Name))
                result = result.Where(r => r.Name.Contains(@params.Name));

            if (!string.IsNullOrWhiteSpace(@params.CreatedByName))
                result = result.Where(r => r.TvDetail.CreatedBys.Any(cr => @params.CreatedByName.Contains(cr.Name)));

            if (!string.IsNullOrWhiteSpace(@params.CreatedByOriginalName))
                result = result.Where(r => r.TvDetail.CreatedBys.Any(cr => @params.OriginalName.Contains(cr.OriginalName)));

            if (@params.CreatedByGender != null)
                result = result.Where(r => r.TvDetail.CreatedBys.Any(cr => @params.CreatedByGender.Value == cr.Gender));


            switch (@params.TvOrderByEnum)
            {
                case Domain.TvAgg.Enums.TvOrderByEnum.TopRated:
                    result = result.OrderBy(d => d.VoteAverage);
                    break;
                case Domain.TvAgg.Enums.TvOrderByEnum.FirstAirDate:
                    result = result.OrderBy(d => d.FirstAirDate);
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
            var model = new TvFilterResult()
            {
                Data = preGenreFilteredList
                    .Skip(skip)
                    .Take(@params.Take)
                    .Select(tv => tv.Map())
                    .ToList(),

                FilterParams = @params
            };

            model.GeneratePaging(preGenreFilteredList.Count(), @params.Take, @params.PageId);
            return model;
        }
    }
}
