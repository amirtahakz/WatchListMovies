using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.ContentImageAgg;
using WatchListMovies.Domain.ContentImageAgg.Enums;
using WatchListMovies.Domain.ContentImageAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.ContentImage
{
    public class ContentImageJobs
    {
        private readonly IContentImageRepository _contentImageRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly ITvRepository _tvRepository;
        private readonly ICastRepository _castRepository;
        private readonly ITvApiService _tvApiService;
        private readonly IMovieApiService _movieApiService;
        private readonly ICastApiService _castApiService;

        public ContentImageJobs(
            IContentImageRepository contentImageRepository,
            IMovieRepository movieRepository,
            ITvRepository tvRepository,
            ICastRepository castRepository,
            ITvApiService tvApiService,
            IMovieApiService movieApiService,
            ICastApiService castApiService)
        {
            _contentImageRepository = contentImageRepository;
            _movieRepository = movieRepository;
            _tvRepository = tvRepository;
            _castRepository = castRepository;
            _tvApiService = tvApiService;
            _movieApiService = movieApiService;
            _castApiService = castApiService;
        }

        public async Task SyncContentImages()
        {

            try
            {
                var casts = await _castRepository.GetAllAsync();
                if (casts.Any())
                {
                    foreach (var cast in casts)
                    {
                        var castImages = await _castApiService.GetCastImages(cast.ApiModelId);
                        await _contentImageRepository.AddRangeIfNotExistAsync(castImages.Map(cast.ApiModelId, ContentImageTypeEnum.Cast));
                        await _contentImageRepository.Save();
                    }
                }

                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Any())
                {
                    foreach (var tv in tvs)
                    {
                        var tvImages = await _tvApiService.GetTvImages(tv.ApiModelId);
                        await _contentImageRepository.AddRangeIfNotExistAsync(tvImages.Map(tv.ApiModelId, ContentImageTypeEnum.Tv));
                        await _contentImageRepository.Save();
                    }
                }

                var movies = await _movieRepository.GetAllAsync();
                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        var movieImages = await _movieApiService.GetMovieImages(movie.ApiModelId);
                        await _contentImageRepository.AddRangeIfNotExistAsync(movieImages.Map(movie.ApiModelId, ContentImageTypeEnum.Movie));
                        await _contentImageRepository.Save();
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
