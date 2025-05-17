using WatchListMovies.Common.Query;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.UserTokens.GetByRefreshToken;

public record GetUserTokenByRefreshTokenQuery(string HashRefreshToken) : IQuery<UserTokenDto?>;