using WatchListMovies.Domain.ListAgg.Enums;

namespace WatchListMovies.Api.ViewModels.List
{
    public class CreateListViewModel
    {
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string Description { get; set; }
        public ListType ListType { get; set; }
    }
}
