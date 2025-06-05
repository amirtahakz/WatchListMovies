using WatchListMovies.Application.IExternalApiServices.Company.ApiModelDTOs;
using WatchListMovies.Domain.CompanyAgg;

namespace WatchListMovies.Application.BackgroundJobs.Company
{
    public static class CompanyMapper
    {
        public static CompanyDetail Map(this GetCompanyDetailsApiModelDto model, Guid parrentId)
        {
            var result = new CompanyDetail()
            {
                ApiModelId = model.Id,
                Description = model.Description,
                LogoPath = model.LogoPath,
                Name = model.Name,
                OriginCountry = model.OriginCountry,
                ParentCompany = model.ParentCompany?.Id,
                ParrentId = parrentId,
                Homepage = model.Homepage,
                Headquarters = model.Headquarters,
            };

            return result;
        }
    }
}
