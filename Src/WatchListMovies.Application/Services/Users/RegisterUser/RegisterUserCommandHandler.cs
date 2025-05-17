using WatchListMovies.Common.Application;
using WatchListMovies.Common.Application.SecurityUtil;
using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Domain.UserAgg.Repository;


namespace WatchListMovies.Application.Services.Users.RegisterUser
{
    internal class RegisterUserCommandHandler : IBaseCommandHandler<RegisterUserCommand>
    {
        private readonly IUserRepository _repository;

        public RegisterUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<OperationResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var user = User.RegisterUser(request.PhoneNumber, Sha256Hasher.Hash(request.Password));

            await _repository.AddAsync(user);
            await _repository.Save();
            return OperationResult.Success();
        }
    }
}
