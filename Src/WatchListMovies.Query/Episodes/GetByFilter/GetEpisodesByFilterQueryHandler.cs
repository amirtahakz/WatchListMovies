using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Episodes.DTOs;

namespace WatchListMovies.Query.Episodes.GetByFilter
{
    public class GetEpisodesByFilterQueryHandler : IQueryHandler<GetEpisodesByFilterQuery, EpisodeFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetEpisodesByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<EpisodeFilterResult> Handle(GetEpisodesByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Episodes.AsQueryable();

            if (@params.Name != null)
                result = result.Where(item => item.Name == @params.Name);

            if (@params.ApiModelIds != null)
                result = result.Where(item => @params.ApiModelIds.Contains((long)item.ApiModelId));

            if (@params.TvApiIds != null)
                result = result.Where(item => @params.TvApiIds.Contains((long)item.TvApiId));

            if (@params.SeasonApiIds != null)
                result = result.Where(item => @params.SeasonApiIds.Contains((long)item.SeasonApiId));

            if (@params.StartAirDate != null)
                result = result.Where(r => r.AirDate >= @params.StartAirDate);

            if (@params.EndAirDate != null)
                result = result.Where(r => r.AirDate <= @params.EndAirDate);


            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new EpisodeFilterResult()
            {
                Data = result
                .OrderBy(item => item.EpisodeNumber)
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
