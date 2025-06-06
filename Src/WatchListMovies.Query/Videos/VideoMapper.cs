using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Query.Videos;
using WatchListMovies.Query.Videos.DTOs;

namespace WatchListMovies.Query.Videos
{
    public static class VideoMapper
    {
        public static VideoDto Map(this Domain.VideoAgg.Video video)
        {
            return new VideoDto()
            {
                CreationDate = video.CreationDate,
                Id = video.Id,
                ApiModelId = video.ApiModelId,
                ContentApiId = video.ContentApiId,
                Iso31661 = video.Iso31661,
                Iso6391 = video.Iso6391,
                Key = video.Key,
                Name = video.Name,
                Official = video.Official,
                PublishedAt = video.PublishedAt,
                Site = video.Site,
                Size = video.Size,
                Type = video.Type,
                VideoMediaType = video.VideoMediaType,
            };
        }

        public static List<VideoDto> Map(this List<Domain.VideoAgg.Video> videos)
        {
            var result = new List<VideoDto>();

            foreach (var item in videos)
                result.Add(item.Map());

            return result;
        }
    }
}
