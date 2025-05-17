using WatchListMovies.Common.Domain;
using WatchListMovies.Common.Domain.Exceptions;

namespace WatchListMovies.Domain.UserAgg
{
    public class UserToken : BaseEntity
    {
        private UserToken()
        {

        }
        public UserToken(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            Guard(hashJwtToken, hashRefreshToken, tokenExpireDate, refreshTokenExpireDate, device);
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


        public void Guard(string hashJwtToken, string hashRefreshToken, DateTime tokenExpireDate, DateTime refreshTokenExpireDate, string device)
        {
            NullOrEmptyDomainDataException.CheckString(hashJwtToken, nameof(HashJwtToken));
            NullOrEmptyDomainDataException.CheckString(hashRefreshToken, nameof(HashRefreshToken));

            if (tokenExpireDate < DateTime.Now)
                throw new InvalidDomainDataException("Invalid Token ExpireDate");

            if (refreshTokenExpireDate < tokenExpireDate)
                throw new InvalidDomainDataException("Invalid RefreshToken ExpireDate");
        }
    }
}
