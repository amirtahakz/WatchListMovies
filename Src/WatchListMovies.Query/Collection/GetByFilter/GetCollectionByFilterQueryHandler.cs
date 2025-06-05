using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Collection.DTOs;

namespace WatchListMovies.Query.Collection.GetByFilter
{
    public class GetCollectionByFilterQueryHandler : IQueryHandler<GetCollectionByFilterQuery, CollectionFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetCollectionByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CollectionFilterResult> Handle(GetCollectionByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Collections.AsQueryable();

            if (@params.Name != null)
                result = result.Where(item => item.Name == @params.Name);

            if (@params.ApiModelIds != null)
                result = result.Where(item => @params.ApiModelIds.Contains((long)item.ApiModelId));


            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CollectionFilterResult()
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
