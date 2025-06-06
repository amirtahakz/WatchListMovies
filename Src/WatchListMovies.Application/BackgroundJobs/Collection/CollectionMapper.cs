using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Collection.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;

namespace WatchListMovies.Application.BackgroundJobs.Collection
{
    public static class CollectionMapper
    {
        public static Domain.CollectionAgg.Collection Map(this BelongsToCollectionApiModelDto requestModel)
        {
            var model = new Domain.CollectionAgg.Collection()
            {
                ApiModelId = requestModel.ApiModelId,
                BackdropPath = requestModel.BackdropPath,
                Name = requestModel.Name,
                PosterPath = requestModel.PosterPath,
            };
            return model;
        }

        public static Domain.CollectionAgg.CollectionDetail Map(this GetCollectionDetailsApiModelDto requestModel , Guid parrentId)
        {
            var model = new Domain.CollectionAgg.CollectionDetail()
            {
                BackdropPath = requestModel.BackdropPath,
                Name = requestModel.Name,
                PosterPath = requestModel.PosterPath,
                ApiModelId = requestModel.Id,
                Overview = requestModel.Overview,
                ParrentId = parrentId,
            };
            return model;
        }

    }
}
