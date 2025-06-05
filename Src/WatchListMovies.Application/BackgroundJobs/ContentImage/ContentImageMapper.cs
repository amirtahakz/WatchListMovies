using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Domain.ContentImageAgg.Enums;

namespace WatchListMovies.Application.BackgroundJobs.ContentImage
{
    public static class ContentImageMapper
    {

        public static List<Domain.ContentImageAgg.ContentImage> Map(this ImagesApiModelDto model, long? contentApiModelId, ContentImageTypeEnum contentImageType)
        {
            var result = new List<Domain.ContentImageAgg.ContentImage>();

            if (model.Images != null)
            {
                foreach (var item in model.Images)
                    result.Add(item.Map(contentApiModelId , contentImageType));
            }

            return result;
        }

        public static Domain.ContentImageAgg.ContentImage Map(this ImagesItemApiModelDto model, long? contentApiModelId , ContentImageTypeEnum contentImageType)
        {
            var result = new Domain.ContentImageAgg.ContentImage()
            {
                ContentApiModelId = contentApiModelId,
                AspectRatio = model.AspectRatio,
                FilePath = model.FilePath,
                Height = model.Height,
                Iso6391 = model.Iso6391,
                VoteAverage = model.VoteAverage,
                VoteCount = model.VoteCount,
                Width = model.Width,
                ContentImageType = contentImageType
            };

            return result;
        }
    }
}
