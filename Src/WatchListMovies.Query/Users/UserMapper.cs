using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users;

public static class UserMapper
{
    public static UserDto Map(this User user)
    {
        return new UserDto()
        {
            Id = user.Id,
            CreationDate = user.CreationDate,
            Family = user.Family,
            PhoneNumber = user.PhoneNumber,
            AvatarName = user.AvatarName,
            Email = user.Email,
            Gender = user.Gender,
            Name = user.Name,
            Password = user.Password,
        };
    }
}