using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Query.Companies.DTOs;
using WatchListMovies.Query.Countries.DTOs;

namespace WatchListMovies.Query.Companies
{
    public static class CompanyMapper
    {
        public static CompanyDto Map(this Company company)
        {
            return new CompanyDto()
            {
                ApiModelId = company.ApiModelId,
                OriginCountry = company.OriginCountry,
                Name = company.Name,
                CompanyDetail = company.CompanyDetail,
                CreationDate = company.CreationDate,
                Id = company.Id,
                LogoPath = company.LogoPath 
            };
        }

        public static List<CompanyDto> Map(this List<Company> companies)
        {
            var result = new List<CompanyDto>();
            foreach (var item in companies)
            {
                result.Add(item.Map());
            }
            return result;
        }
    }
}
