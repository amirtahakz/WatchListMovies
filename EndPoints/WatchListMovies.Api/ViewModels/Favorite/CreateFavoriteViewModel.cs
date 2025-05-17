using WatchListMovies.Domain.FavoriteAgg.Enums;

namespace WatchListMovies.Api.ViewModels.Favorite
{
    public class CreateFavoriteViewModel
    {
        public Guid SubjectId { get; set; }
        public Guid ListId { get; set; }
        public string Note { get; set; }
        public FavoriteType FavoriteType { get; set; }
    }
}
