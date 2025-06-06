using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Video;
using WatchListMovies.Domain.MovieAgg.Repository;
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
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncTvVideos()
        {
            try
            {
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Any())
                {
                    foreach (var tv in tvs)
                    {
                        var apiMovieVideos = await _videoApiService.GetTvVideos(tv.ApiModelId);

                        await _videoRepository.AddRangeIfNotExistAsync(apiMovieVideos.Videos.Map(tv.ApiModelId, VideoMediaType.Tv));
                        await _videoRepository.Save();
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
