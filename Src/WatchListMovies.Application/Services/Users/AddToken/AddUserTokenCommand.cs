using WatchListMovies.Common.Application;

namespace WatchListMovies.Application.Services.Users.AddToken
{
    public class AddUserTokenCommand : IBaseCommand
    {
        public AddUserTokenCommand(Guid userId, string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            UserId = userId;
            HashJwtToken = hashJwtToken;
            HashRefreshToken = hashRefreshToken;
            TokenExpireDate = tokenExpireDate;
            RefreshTokenExpireDate = refreshTokenExpireDate;
            Device = device;
        }
        public Guid UserId { get; set; }
        public string HashJwtToken { get; set; }
        public string HashRefreshToken { get; set; }
        public DateTime TokenExpireDate { get; set; }
        public DateTime RefreshTokenExpireDate { get; set; }
        public string Device { get; set; }

    }
}
