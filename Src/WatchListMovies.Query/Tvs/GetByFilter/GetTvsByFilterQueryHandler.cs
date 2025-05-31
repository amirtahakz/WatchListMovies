using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Query;
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

            var result = _context.Tvs
                .Include(c => c.TvDetail)
                .Include(v => v.TvDetail.Casts)
                .Include(v => v.TvDetail.Crews)
                .AsQueryable();

            if (@params.Id != null)
                result = result.Where(r => r.Id == @params.Id);

            if (@params.Adult != null)
                result = result.Where(r => r.Adult == @params.Adult);

            if (@params.ApiModelId != null)
                result = result.Where(r => r.ApiModelId == @params.ApiModelId);

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

            // MovieDetails
            //if (!string.IsNullOrWhiteSpace(@params.ImdbId))
            //    result = result.Where(r => r.TvDetail.ImdbId.Contains(@params.ImdbId));

            if (@params.GenreIds != null)
                result = result.Where(r => r.TvDetail.Genres.Any(genre => @params.GenreIds.Contains((long)genre.ApiModelId)));

            if (@params.GenreNames != null)
                result = result.Where(r => r.TvDetail.Genres.Any(genre => @params.GenreNames.Contains(genre.Name)));

            if (@params.CompanyNames != null)
                result = result.Where(r => r.TvDetail.ProductionCompanies.Any(pc => @params.CompanyNames.Contains(pc.Name)));

            if (@params.CountryNames != null)
                result = result.Where(r => r.TvDetail.Genres.Any(c => @params.CountryNames.Contains(c.Name)));

            if (@params.SpokenLanguageEnglishNames != null)
                result = result.Where(r => r.TvDetail.SpokenLanguages.Any(sp => @params.SpokenLanguageEnglishNames.Contains(sp.Name)));


            switch (@params.TvOrderByEnum)
            {
                case Domain.TvAgg.Enums.TvOrderByEnum.TopRated:
                    result.OrderBy(d => d.VoteAverage);
                    break;
                case Domain.TvAgg.Enums.TvOrderByEnum.FirstAirDate:
                    result.OrderBy(d => d.FirstAirDate);
                    break;
                default:
                    result.OrderByDescending(d => d.Id);
                    break;
            }

            var skip = (@params.PageId - 1) * @params.Take;
            var model = new TvFilterResult()
            {
                Data = await result
                    .Skip(skip)
                    .Take(@params.Take)
                    .Select(tv => tv.Map())
                    .ToListAsync(cancellationToken),

                FilterParams = @params
            };

            model.GeneratePaging(result, @params.Take, @params.PageId);
            return model;
        }
    }
}
