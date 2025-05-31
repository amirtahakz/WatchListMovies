using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.MovieAgg
{
    public class MovieKeyYoutubeTrailer : BaseEntity
    {
        public MovieKeyYoutubeTrailer()
        {
            
        }
        public MovieKeyYoutubeTrailer(
            Guid mediaId,
            string? apiModelId,
            string? iso6391,
            string? iso31661,
            string? name,
            string? key,
            string? site,
            long? size,
            string? type,
            bool? official,
            DateTime? publishedAt)
        {
            MediaId = mediaId;
            ApiModelId = apiModelId;
            Iso6391 = iso6391;
            Iso31661 = iso31661;
            Name = name;
            Key = key;
            Site = site;
            Size = size;
            Type = type;
            Official = official;
            PublishedAt = publishedAt;
        }

        public Guid MediaId { get; set; }
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
    }
}
