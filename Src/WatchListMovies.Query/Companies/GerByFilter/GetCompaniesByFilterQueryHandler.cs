using Microsoft.EntityFrameworkCore;
using System.Linq;
using WatchListMovies.Common.Query;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Companies.DTOs;

namespace WatchListMovies.Query.Companies.GerByFilter
{
    public class GetCompaniesByFilterQueryHandler : IQueryHandler<GetCompaniesByFilterQuery, CompanyFilterResult>
    {
        private readonly ApplicationDbContext _context;

        public GetCompaniesByFilterQueryHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<CompanyFilterResult> Handle(GetCompaniesByFilterQuery request, CancellationToken cancellationToken)
        {
            var @params = request.FilterParams;

            var result = _context.Companies.AsQueryable();

            if (@params.Name != null)
                result = result.Where(item=>item.Name == @params.Name);

            if (@params.OriginCountry != null)
                result = result.Where(item => item.OriginCountry == @params.OriginCountry);

            if (@params.ApiModelIds != null)
                result = result.Where(item => @params.ApiModelIds.Contains((long)item.ApiModelId));


            // صفحه‌بندی و مپ کردن به DTO
            var skip = (@params.PageId - 1) * @params.Take;
            var model = new CompanyFilterResult()
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
