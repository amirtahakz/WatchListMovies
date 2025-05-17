using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Domain.UserAgg.Repository;
using WatchListMovies.Common.Application.SecurityUtil;

namespace WatchListMovies.Application.Services.Users.Create
{
    public class CreateUserCommandHandler : Common.Application.IBaseCommandHandler<CreateUserCommand>
    {
        private readonly IUserRepository _repository;
        public CreateUserCommandHandler(IUserRepository repository)
        {
            _repository = repository;
        }

        public async Task<Common.Application.OperationResult> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var password = Sha256Hasher.Hash(request.Password);
            var user = new User(request.Name, request.Family, request.PhoneNumber
                , request.Email, password, request.Gender);

            _repository.Add(user);
            await _repository.Save();
            return Common.Application.OperationResult.Success();
        }
    }
}
