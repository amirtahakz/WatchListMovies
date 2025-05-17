using WatchListMovies.Common.Application;
using WatchListMovies.Domain.FavoriteAgg.Enums;

namespace WatchListMovies.Application.Services.Favorite.Create
{
    public class CreateFavoriteCommand : IBaseCommand<Guid>
    {
        public Guid UserId { get; set; }
        public Guid SubjectId { get; set; }
        public Guid ListId { get; set; }
        public string Note { get; set; }
        public FavoriteType FavoriteType { get; set; }
    }
}
