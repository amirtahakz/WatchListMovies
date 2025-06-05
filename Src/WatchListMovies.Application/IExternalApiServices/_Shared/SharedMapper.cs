using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Domain.CompanyAgg;

namespace WatchListMovies.Application.IExternalApiServices._Shared
{
    public static class SharedMapper
    {

        public static List<Domain.CompanyAgg.Company> Map(this List<ProductionCompanyApiModelDto> requestModels)
        {
            var result = new List<Domain.CompanyAgg.Company>();

            foreach (var item in requestModels)
                result.Add(item.Map());

            return result;
        }

        public static Domain.CompanyAgg.Company Map(this ProductionCompanyApiModelDto requestModel)
        {
            var model = new Domain.CompanyAgg.Company()
            {
                ApiModelId = requestModel.ApiModelId,
                LogoPath = requestModel.LogoPath,
                Name = requestModel.Name,
                OriginCountry = requestModel.OriginCountry,
            };

            return model;
        }


    }
}
