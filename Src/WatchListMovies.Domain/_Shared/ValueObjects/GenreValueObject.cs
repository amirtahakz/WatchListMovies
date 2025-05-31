using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects
{
    public class GenreValueObject : BaseValueObject
    {
        public GenreValueObject()
        {

        }
        public GenreValueObject(Guid? mediaId , long? apiModelId, string? name)
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
