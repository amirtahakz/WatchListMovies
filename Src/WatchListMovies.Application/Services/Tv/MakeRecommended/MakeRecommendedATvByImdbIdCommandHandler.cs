using WatchListMovies.Common.Application;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.Services.Tv.MakeRecommended
{
    public class MakeRecommendedATvByApiModelIdCommandHandler : IBaseCommandHandler<MakeRecommendedATvByApiModelIdCommand, bool>
    {
        private readonly ITvRepository _tvRepository;

        public MakeRecommendedATvByApiModelIdCommandHandler(ITvRepository tvRepository)
        {
            _tvRepository = tvRepository;
        }

        public async Task<OperationResult<bool>> Handle(MakeRecommendedATvByApiModelIdCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var tv = await _tvRepository.GetTrackingByImdbIdAsync(request.ApiModelId);
                if (tv == null)
                    throw new Exception("Tv Not Found.");

                tv.MakeRecommended();
                await _tvRepository.Save();
                return OperationResult<bool>.Success(true);
            }
            catch (Exception)
            {
                return OperationResult<bool>.Success(false);

            }

        }
    }
}
