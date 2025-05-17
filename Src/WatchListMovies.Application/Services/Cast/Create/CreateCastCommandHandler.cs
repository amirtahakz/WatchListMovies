using WatchListMovies.Common.Application;
using WatchListMovies.Domain.CastAgg.Repository;

namespace WatchListMovies.Application.Services.Cast.Create
{
    public class CreateCastCommandHandler : IBaseCommandHandler<CreateCastCommand, Guid>
    {
        private readonly ICastRepository _castRepository;

        public CreateCastCommandHandler(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<OperationResult<Guid>> Handle(CreateCastCommand request, CancellationToken cancellationToken)
        {
            var entityModel = new Domain.CastAgg.Cast(request.Adult, request.Gender, request.ApiModelId, request.KnownForDepartment,
                request.Name, request.OriginalName, request.Popularity, request.ProfilePath, request.CastImages, request.CastExternalId, request.CastDetails, request.CastKnownFors);
            await _castRepository.AddAsync(entityModel);
            await _castRepository.Save();

            return OperationResult<Guid>.Success(entityModel.Id);
        }
    }
}
