using WatchListMovies.Common.Application;


namespace WatchListMovies.Application.Services.Users.RegisterUser
{
    public class RegisterUserCommand : IBaseCommand
    {
        public RegisterUserCommand(string phoneNumber, string password)
        {
            PhoneNumber = phoneNumber;
            Password = password;
        }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
    }
}
