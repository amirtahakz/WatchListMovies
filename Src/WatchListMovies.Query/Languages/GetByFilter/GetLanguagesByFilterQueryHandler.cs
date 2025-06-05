using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Languages.DTOs;

namespace WatchListMovies.Query.Languages.GetByFilter
{
    public class GetLanguagesByFilterQueryHandler : IQueryHandler<GetLanguagesByFilterQuery, LanguageFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetLanguagesByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<LanguageFilterResult> Handle(GetLanguagesByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Languages.AsEnumerable();

            if (@params.Iso6391 != null)
                result = result.Where(language => @params.Iso6391.Contains(language.Iso6391));



            if (@params.EnglishName != null)
                result = result.Where(language => @params.EnglishName.Contains(language.EnglishName));

            if (@params.Name != null)
                result = result.Where(language => @params.Name.Contains(language.Name));

            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new LanguageFilterResult()
            {
                Data = result
                .Skip(skip)
                .Take(@params.Take)
                .Select(language => language.Map())
                .ToList(),

                FilterParams = @params
            };

            model.GeneratePaging(result.Count(), @params.Take, @params.PageId);
            return model;
        }

    }
}
