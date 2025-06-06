using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Video.ApiModelDTOs;
using WatchListMovies.Domain.TvAgg.Repository;
using WatchListMovies.Domain.VideoAgg.Enums;
using WatchListMovies.Domain.VideoAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Video
{
    public static class VideoMapper
    {

        public static Domain.VideoAgg.Video Map(this GetVideosItemApiModelDto video, long? contentApiId , VideoMediaType videoMediaType)
        {
            var model = new Domain.VideoAgg.Video()
            {
                ApiModelId = video.Id,
                ContentApiId = contentApiId,
                Iso31661 = video.Iso31661,
                Iso6391 = video.Iso6391,
                Key = video.Key,
                Name = video.Name,
                Official = video.Official,
                PublishedAt = video.PublishedAt,
                Site = video.Site,
                Size = video.Size,
                Type = video.Type,
                VideoMediaType = videoMediaType,
            };
            return model;
        }

        public static List<Domain.VideoAgg.Video> Map(this List<GetVideosItemApiModelDto> videos, long? contentApiId, VideoMediaType videoMediaType)
        {
            var result = new List<Domain.VideoAgg.Video>();

            foreach (var item in videos)
                result.Add(item.Map(contentApiId , videoMediaType));

            return result;
        }
    }
}
