using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Season;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.EpisodeAgg.Repository;
using WatchListMovies.Domain.SeasonAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Episode
{
    public class EpisodeJobs
    {
        private readonly ISeasonRepository _seasonRepository;
        private readonly ITvRepository _tvRepository;
        private readonly ITvApiService _tvApiService;
        private readonly ISeasonApiService _seasonApiService;
        private readonly IEpisodeRepository _episodeRepository;

        public EpisodeJobs(
            ISeasonRepository seasonRepository,
            ITvRepository tvRepository,
            ITvApiService tvApiService,
            ISeasonApiService seasonApiService,
            IEpisodeRepository episodeRepository)
        {
            _seasonRepository = seasonRepository;
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
            _seasonApiService = seasonApiService;
            _episodeRepository = episodeRepository;
        }

        public async Task SyncEpisodes()
        {
            try
            {
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Any())
                {
                    foreach (var tv in tvs)
                    {
                        var tvSeasons = await _seasonRepository.GetSeasonsByTvApiIdAsync((long)tv.ApiModelId);
                        foreach (var tvSeason in tvSeasons)
                        {
                            var apiSeasonDetails = await _seasonApiService.GetSeasonDetails((long)tv.ApiModelId, (int)tvSeason.SeasonNumber);
                            if (apiSeasonDetails != null)
                            {
                                await _episodeRepository.AddRangeIfNotExistAsync(apiSeasonDetails.Episodes.Map((long)tvSeason.SeasonNumber ,(long)tv.ApiModelId));
                                await _episodeRepository.Save();
                            }
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
