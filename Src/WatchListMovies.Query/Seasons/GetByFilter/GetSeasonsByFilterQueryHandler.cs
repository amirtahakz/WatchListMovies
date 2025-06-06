using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Seasons.DTOs;

namespace WatchListMovies.Query.Seasons.GetByFilter
{
    public class GetSeasonsByFilterQueryHandler : IQueryHandler<GetSeasonsByFilterQuery, SeasonFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetSeasonsByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SeasonFilterResult> Handle(GetSeasonsByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Seasons.AsQueryable();

            if (@params.Name != null)
                result = result.Where(item => item.Name == @params.Name);

            
            if (@params.ApiModelId != null)
                result = result.Where(item => item.ApiModelId == @params.ApiModelId);

            if (@params.TvApiIds != null)
                result = result.Where(item => @params.TvApiIds.Contains((long)item.TvApiId));

            if (@params.StartAirDate != null)
                result = result.Where(r => r.AirDate >= @params.StartAirDate);

            if (@params.EndAirDate != null)
                result = result.Where(r => r.AirDate <= @params.EndAirDate);


            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new SeasonFilterResult()
            {
                Data = result
                .OrderBy(item => item.SeasonNumber)
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
