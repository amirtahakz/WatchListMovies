
using WatchListMovies.Common.Application;
using WatchListMovies.Domain.FavoriteAgg.Repository;
using WatchListMovies.Domain.ListAgg.Enums;

namespace WatchListMovies.Application.Services.List.Create;

public class CreateListCommand : IBaseCommand<Guid>
{
    public Guid UserId { get; set; }
    public string Name { get; set; }
    public bool IsPrivate { get; set; }
    public string Description { get; set; }
    public ListType ListType { get; set; }
}