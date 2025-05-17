using WatchListMovies.Common.Application;


namespace WatchListMovies.Application.Services.Users.ChangePassword
{
    public class ChangeUserPasswordCommand : IBaseCommand
    {

        public Guid UserId { get; set; }
        public string CurrentPassword { get; set; }
        public string Password { get; set; }
    }
}
