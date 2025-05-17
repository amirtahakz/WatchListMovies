using WatchListMovies.Common.Query;
using WatchListMovies.Query.Users.DTOs;

namespace WatchListMovies.Query.Users.GetByPhoneNumber;

public record GetUserByPhoneNumberQuery(string PhoneNumber) : IQuery<UserDto?>;