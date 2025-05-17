using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.FavoriteAgg.Enums;

namespace WatchListMovies.Domain.FavoriteAgg
{
    public class Favorite : BaseEntity
    {
        public Favorite(
            Guid userId,
            Guid subjectId,
            Guid listId,
            string note,
            FavoriteType favoriteType)
        {
            UserId = userId;
            SubjectId = subjectId;
            ListId = listId;
            Note = note;
            FavoriteType = favoriteType;
        }

        public Favorite()
        {

        }

        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ListId { get; set; }
        public string Note { get; set; }
        public FavoriteType FavoriteType { get; set; }
    }
}
