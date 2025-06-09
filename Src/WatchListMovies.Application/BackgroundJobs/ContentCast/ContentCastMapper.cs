using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentCastAgg.Enums;

namespace WatchListMovies.Application.BackgroundJobs.ContentCast
{
    public static class ContentCastMapper
    {
        public static Domain.ContentCastAgg.ContentCast Map(
            this CreditsOfCastItemApiModelDto requestModel,
            long? castApiModelId,
            long? contentApiModelId,
            ContentTypeEnum contentTypeEnum ,
            CreditTypeEnum creditTypeEnum)
        {
            var model = new Domain.ContentCastAgg.ContentCast()
            {
                CastApiModelId = castApiModelId,
                ContentType = contentTypeEnum,
                CreditType = creditTypeEnum,
                ContentApiModelId = contentApiModelId,
                Character = requestModel?.Character ?? default,
                Department = requestModel?.Department ?? default,
                Job = requestModel?.Job ?? default,
                CreditId = requestModel?.CreditId,
            };

            return model;
        }

        public static List<Domain.ContentCastAgg.ContentCast> Map(
            this List<CreditsOfCastItemApiModelDto> requestModels,
            long? castApiModelId,
            long? contentApiModelId,
            ContentTypeEnum contentTypeEnum,
            CreditTypeEnum creditTypeEnum)
        {
            var result = new List<Domain.ContentCastAgg.ContentCast>();

            foreach (var item in requestModels)
                result.Add(item.Map(castApiModelId , contentApiModelId , contentTypeEnum , creditTypeEnum));

            return result;
        }
    }
}
