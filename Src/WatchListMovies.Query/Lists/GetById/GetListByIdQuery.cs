using WatchListMovies.Common.Query;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Lists.GetById;

public class GetListByIdQuery : IQuery<ListDto?>
{
    public GetListByIdQuery(Guid listId)
    {
        ListId = listId;
    }

    public Guid ListId { get; private set; }
}