using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.BackgroundJobs.ContentImage;
using WatchListMovies.Application.IExternalApiServices.Season;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.ContentImageAgg.Enums;
using WatchListMovies.Domain.ContentImageAgg.Repository;
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
                const int batchSize = 100;
                long totalCount = await _tvRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var tvs = await _tvRepository.GetBatchAsync(skip, batchSize);
                    var tvSemaphore = new SemaphoreSlim(5);

                    var tvTasks = tvs.Select(tv => ProcessTvAsync(tv, tvSemaphore));
                    await Task.WhenAll(tvTasks);
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
        async Task ProcessTvAsync(Domain.TvAgg.Tv tv, SemaphoreSlim tvSemaphore)
        {
            await tvSemaphore.WaitAsync();
            try
            {
                var tvSeasons = await _seasonRepository.GetSeasonsByTvApiIdAsync(tv.ApiModelId);
                var allEpisodes = new ConcurrentBag<Domain.EpisodeAgg.Episode>();

                await Parallel.ForEachAsync(tvSeasons,
                    new ParallelOptions { MaxDegreeOfParallelism = 5 },
                    async (tvSeason, ct) =>
                    {
                        var apiSeasonDetails = await _seasonApiService.GetSeasonDetails(tv.ApiModelId, tvSeason.SeasonNumber);
                        foreach (var ep in apiSeasonDetails.Episodes.Map(tvSeason.SeasonNumber, tv.ApiModelId))
                            allEpisodes.Add(ep);
                    });

                await _episodeRepository.BulkInsertIfNotExistAsync(allEpisodes.ToList());
            }
            finally
            {
                tvSemaphore.Release();
            }
        }
    }
}
