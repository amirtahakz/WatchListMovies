using WatchListMovies.Common.Application;
using Microsoft.AspNetCore.Http;
using WatchListMovies.Domain.UserAgg.Enums;

namespace WatchListMovies.Application.Services.Users.Edit
{
    public class EditUserCommand : IBaseCommand
    {
        public Guid UserId { get; set; }
        public IFormFile? Avatar { get; set; }
        public string Name { get; set; }
        public string Family { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public Gender Gender { get; set; }
    }
}
