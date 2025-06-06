using System.Linq;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.SeasonAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Season
{
    public class SeasonJobs
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly ITvRepository _tvRepository;
        private readonly ITvApiService _tvApiService;

        public SeasonJobs(
            ISeasonRepository seasonRepository,
            ITvRepository tvRepository,
            ITvApiService tvApiService)
        {
            _seasonRepository = seasonRepository;
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
        }

        public async Task SyncSeasons()
        {
            try
            {
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Any())
                {
                    foreach (var item in tvs)
                    {
                        var apiTvDetails = await _tvApiService.GetTvDetails(item.ApiModelId);
                        if (apiTvDetails.Seasons != null)
                        {
                            await _seasonRepository.AddRangeIfNotExistAsync(apiTvDetails.Seasons.Map(item.ApiModelId));
                            await _seasonRepository.Save();
                        }
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
