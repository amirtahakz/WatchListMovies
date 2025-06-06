using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Networks.DTOs;

namespace WatchListMovies.Query.Networks.GetByFilter
{
    public class GetNetworksByFilterQueryHandler : IQueryHandler<GetNetworksByFilterQuery, NetworkFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetNetworksByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<NetworkFilterResult> Handle(GetNetworksByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Networks.AsQueryable();

            if (@params.Name != null)
                result = result.Where(item => item.Name == @params.Name);

            if (@params.OriginCountry != null)
                result = result.Where(item => item.OriginCountry == @params.OriginCountry);

            if (@params.ApiModelIds != null)
                result = result.Where(item => @params.ApiModelIds.Contains((long)item.ApiModelId));


            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new NetworkFilterResult()
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
