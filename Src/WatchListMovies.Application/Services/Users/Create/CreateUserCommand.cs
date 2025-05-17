using WatchListMovies.Common.Application;
using WatchListMovies.Domain.UserAgg.Enums;

namespace WatchListMovies.Application.Services.Users.Create
{
    public class CreateUserCommand : IBaseCommand
    {
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Gender Gender { get; set; }
    }
}
