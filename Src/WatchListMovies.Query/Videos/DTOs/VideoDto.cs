using WatchListMovies.Common.Query;
using WatchListMovies.Domain.VideoAgg.Enums;
using WatchListMovies.Query.Seasons.DTOs;

namespace WatchListMovies.Query.Videos.DTOs
{
    public class VideoDto : BaseDto
    {
        public long? ContentApiId { get; set; }
        public string? ApiModelId { get; set; }
        public string? Iso6391 { get; set; }
        public string? Iso31661 { get; set; }
        public string? Name { get; set; }
        public string? Key { get; set; }
        public string? Site { get; set; }
        public long? Size { get; set; }
        public string? Type { get; set; }
        public bool? Official { get; set; }
        public DateTime? PublishedAt { get; set; }
        public VideoMediaType? VideoMediaType { get; set; }
    }

    public class VideoFilterParams : BaseFilterParam
    {
        public long? ContentApiId { get; set; }
        public string? Site { get; set; }
        public string? Type { get; set; }
        public DateTime? StartPublishedAt { get; set; }
        public DateTime? EndPublishedAt { get; set; }
        public VideoMediaType? VideoMediaType { get; set; }
    }
    public class VideoFilterResult : BaseFilter<VideoDto, VideoFilterParams>
    {
        
    }
}
