using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Domain.CompanyAgg;

namespace WatchListMovies.Application.IExternalApiServices._Shared
{
    public static class SharedMapper
    {

        public static List<Company> Map(this List<ProductionCompanyApiModelDto> requestModels)
        {
            var result = new List<Company>();

            foreach (var item in requestModels)
                result.Add(item.Map());

            return result;
        }

        public static Company Map(this ProductionCompanyApiModelDto requestModel)
        {
            var model = new Company()
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
