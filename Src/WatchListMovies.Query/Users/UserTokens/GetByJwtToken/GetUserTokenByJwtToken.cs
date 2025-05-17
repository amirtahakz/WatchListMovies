using WatchListMovies.Common.Query;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.UserTokens.GetByJwtToken;

public record GetUserTokenByJwtTokenQuery(string HashJwtToken) : IQuery<UserTokenDto?>;