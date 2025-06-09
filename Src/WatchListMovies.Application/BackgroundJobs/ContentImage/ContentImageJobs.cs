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
using WatchListMovies.Domain.ContentCastAgg.Enums;
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

        public async Task SyncCastImages()
        {

            try
            {
                const int batchSize = 100;
                long totalCount = await _castRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var casts = await _castRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var castTask = casts.Select(async cast =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var castImages = await _castApiService.GetCastImages(cast.ApiModelId);
                            return castImages.Map(cast.ApiModelId, ContentImageTypeEnum.Cast);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedCastImages = await Task.WhenAll(castTask);


                    // ذخیره دسته‌ای
                    await _contentImageRepository.BulkInsertIfNotExistAsync(
                        updatedCastImages
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

        public async Task SyncTvImages()
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
                            var tvImages = await _tvApiService.GetTvImages(tv.ApiModelId);
                            return tvImages.Map(tv.ApiModelId, ContentImageTypeEnum.Tv);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvImages = await Task.WhenAll(castTask);


                    // ذخیره دسته‌ای
                    await _contentImageRepository.BulkInsertIfNotExistAsync(
                        updatedTvImages
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

        public async Task SyncMovieImages()
        {

            try
            {
                const int batchSize = 100;
                long totalCount = await _movieRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var movies = await _movieRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var castTask = movies.Select(async movie =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var movieImages = await _movieApiService.GetMovieImages(movie.ApiModelId);
                            return movieImages.Map(movie.ApiModelId, ContentImageTypeEnum.Tv);
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvImages = await Task.WhenAll(castTask);


                    // ذخیره دسته‌ای
                    await _contentImageRepository.BulkInsertIfNotExistAsync(
                        updatedTvImages
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
