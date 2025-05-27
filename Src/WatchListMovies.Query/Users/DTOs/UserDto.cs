using WatchListMovies.Common.Query;
using WatchListMovies.Common.Query.Filter;
using WatchListMovies.Domain.UserAgg.Enums;

namespace WatchListMovies.Query.Users.DTOs;

public class UserDto : BaseDto
{
    public string Name { get; set; }
    public string Family { get; set; }
    public string PhoneNumber { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string AvatarName { get; set; }
    public Gender Gender { get; set; }
}

public class UserFilterParams : BaseFilterParam
{
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; }
    public Guid? Id { get; set; }
}
public class UserFilterResult : BaseFilter<UserDto, UserFilterParams>
{

}