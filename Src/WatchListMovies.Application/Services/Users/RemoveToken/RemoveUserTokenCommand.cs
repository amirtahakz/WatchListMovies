using WatchListMovies.Common.Application;


namespace WatchListMovies.Application.Services.Users.RemoveToken
{
    public record RemoveUserTokenCommand(Guid UserId, Guid TokenId) : IBaseCommand<string>;
}
