using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Countries.DTOs;

namespace WatchListMovies.Query.Countries.GetByFilter
{
    public class GetCountriesByFilterQueryHandler : IQueryHandler<GetCountriesByFilterQuery, CountryFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetCountriesByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CountryFilterResult> Handle(GetCountriesByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Countries.AsEnumerable();

            if (@params.Iso31661 != null)
                result = result.Where(language => @params.Iso31661.Contains(language.Iso31661));

            if (@params.EnglishName != null)
                result = result.Where(language => @params.EnglishName.Contains(language.EnglishName));

            if (@params.NativeName != null)
                result = result.Where(language => @params.NativeName.Contains(language.NativeName));

            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CountryFilterResult()
            {
                Data = result
                .Skip(skip)
                .Take(@params.Take)
                .Select(country => country.Map())
                .ToList(),

                FilterParams = @params
            };

            model.GeneratePaging(result.Count(), @params.Take, @params.PageId);
            return model;
        }

    }
}
