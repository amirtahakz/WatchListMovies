using WatchListMovies.Common.Application;
using Microsoft.AspNetCore.Http;
using WatchListMovies.Application._Utilities;
using WatchListMovies.Common.Application.FileUtil.Interfaces;
using WatchListMovies.Domain.UserAgg.Repository;

namespace WatchListMovies.Application.Services.Users.Edit
{
    public class EditUserCommandHandler : IBaseCommandHandler<EditUserCommand>
    {
        private readonly IUserRepository _repository;
        private readonly IFileService _fileService;
        public EditUserCommandHandler(IUserRepository repository, IFileService fileService)
        {
            _repository = repository;
            _fileService = fileService;
        }

        public async Task<OperationResult> Handle(EditUserCommand request, CancellationToken cancellationToken)
        {
            var user = await _repository.GetTracking(request.UserId);
            if (user == null)
                return OperationResult.NotFound();

            var oldAvatar = user.AvatarName;
            user.Edit(request.Name, request.Family, request.PhoneNumber, request.Email, request.Gender);
            if (request.Avatar != null)
            {
                var imageName = await _fileService
                    .SaveFileAndGenerateName(request.Avatar, Directories.UserAvatars);
                user.SetAvatar(imageName);
            }

            DeleteOldAvatar(request.Avatar, oldAvatar);
            await _repository.Save();
            return OperationResult.Success();
        }

        private void DeleteOldAvatar(IFormFile? avatarFile, string oldImage)
        {
            if (avatarFile == null || oldImage == "avatar.png")
                return;

            _fileService.DeleteFile(Directories.UserAvatars, oldImage);
        }
    }
}
