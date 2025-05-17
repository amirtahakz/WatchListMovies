using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects
{
    public class Genre : BaseValueObject
    {
        public Genre()
        {

        }
        public Genre(Guid? mediaId , long? apiModelId, string? name)
        {
            MediaId = mediaId;
            ApiModelId = apiModelId;
            Name = name;
        }

        public Guid? MediaId { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
    }
}
