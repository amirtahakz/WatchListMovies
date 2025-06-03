using WatchListMovies.Application.Services.Cast.MakeRecommended;
using WatchListMovies.Common.Application;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.Services.Cast.MakeRecommended
{
    public class MakeRecommendedACastByApiModelIdCommandHandler : IBaseCommandHandler<MakeRecommendedACastByApiModelIdCommand, bool>
    {
        private readonly ICastRepository _castRepository;

        public MakeRecommendedACastByApiModelIdCommandHandler(ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<OperationResult<bool>> Handle(MakeRecommendedACastByApiModelIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var cast = await _castRepository.GetTrackingByApiModelIdAsync(request.ApiModelId);
                if (cast == null)
                    throw new Exception("CreditsOfCastItemApiModelDto Not Found.");

                cast.MakeRecommended();
                await _castRepository.Save();
                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                return OperationResult<bool>.Success(false);

            }

        }
    }
}
