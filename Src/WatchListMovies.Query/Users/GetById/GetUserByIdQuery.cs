using WatchListMovies.Common.Query;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.GetById;

public class GetUserByIdQuery : IQuery<UserDto?>
{
    public GetUserByIdQuery(Guid userId)
    {
        UserId = userId;
    }

    public Guid UserId { get; private set; }
}