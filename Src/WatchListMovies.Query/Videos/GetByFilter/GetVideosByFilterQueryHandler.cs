using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Videos.DTOs;

namespace WatchListMovies.Query.Videos.GetByFilter
{
    public class GetVideosByFilterQueryHandler : IQueryHandler<GetVideosByFilterQuery, VideoFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetVideosByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<VideoFilterResult> Handle(GetVideosByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Videos.AsQueryable();

            if (@params.ContentApiId != null)
                result = result.Where(item => item.ContentApiId == @params.ContentApiId);

            if (!string.IsNullOrEmpty(@params.Site))
                result = result.Where(item => item.Site == @params.Site);

            if (!string.IsNullOrEmpty(@params.Type))
                result = result.Where(item => item.Type == @params.Type);   

            if (@params.StartPublishedAt != null)
                result = result.Where(r => r.PublishedAt >= @params.StartPublishedAt);

            if (@params.EndPublishedAt != null)
                result = result.Where(r => r.PublishedAt <= @params.EndPublishedAt);

            if (@params.VideoMediaType != null)
                result = result.Where(item => item.VideoMediaType == @params.VideoMediaType);


            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new VideoFilterResult()
            {
                Data = result
                .OrderByDescending(item => item.PublishedAt)
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
