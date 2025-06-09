using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Application.IExternalApiServices.Video;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.NetworkAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;
using WatchListMovies.Domain.VideoAgg.Enums;
using WatchListMovies.Domain.VideoAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Video
{
    public class VideoJobs
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ITvRepository _tvRepository;
        private readonly IVideoApiService _videoApiService;
        private readonly IVideoRepository _videoRepository;

        public VideoJobs(
            IMovieRepository movieRepository,
            ITvRepository tvRepository,
            IVideoApiService videoApiService,
            IVideoRepository videoRepository)
        {
            _movieRepository = movieRepository;
            _tvRepository = tvRepository;
            _videoApiService = videoApiService;
            _videoRepository = videoRepository;
        }

        public async Task SyncMovieVideos()
        {
            try
            {
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        var apiMovieVideos = await _videoApiService.GetMovieVideos(movie.ApiModelId);

                        await _videoRepository.AddRangeIfNotExistAsync(apiMovieVideos.Videos.Map(movie.ApiModelId , VideoMediaType.Movie));
                        await _videoRepository.Save();
                    }
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SyncTvVideos()
        {
            try
            {
                const int batchSize = 100;
                long totalCount = await _tvRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var tvs = await _tvRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var castTask = tvs.Select(async tv =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiMovieVideos = await _videoApiService.GetTvVideos(tv.ApiModelId);
                            return apiMovieVideos.Videos.Map(tv.ApiModelId, VideoMediaType.Tv);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvNetworks = await Task.WhenAll(castTask);


                    // ذخیره دسته‌ای
                    await _videoRepository.BulkInsertIfNotExistAsync(
                        updatedTvNetworks
                        .SelectMany(m => m) // flatten
                        .Select(cast => cast) // تبدیل به domain model یا entity
                        .ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
