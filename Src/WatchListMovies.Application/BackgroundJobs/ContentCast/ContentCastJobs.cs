using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.ContentCastAgg.Enums;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.ContentCast
{
    public class ContentCastJobs
    {
        private readonly IContentCastRepository _contentCastRepository;
        private readonly ICastApiService _castApiService;
        private readonly ICastRepository _castRepository;

        public ContentCastJobs(IContentCastRepository contentCastRepository, ICastApiService castApiService, ICastRepository castRepository)
        {
            _contentCastRepository = contentCastRepository;
            _castApiService = castApiService;
            _castRepository = castRepository;
        }

        public async Task SyncContentCasts()
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
                    var tasks = casts.Select(async cast =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var tvApiTask = _castApiService.GetTvCreditsOfCast(cast.ApiModelId);
                            var movieApiTask = _castApiService.GetMovieCreditsOfCast(cast.ApiModelId);

                            await Task.WhenAll(tvApiTask, movieApiTask);

                            var tvCredits = tvApiTask.Result;
                            var movieCredits = movieApiTask.Result;

                            return new[]
                            {
                                movieCredits.Casts?.Map(cast.ApiModelId, movieCredits.Id, ContentTypeEnum.Movie, CreditTypeEnum.Cast),
                                movieCredits.Crews?.Map(cast.ApiModelId, movieCredits.Id, ContentTypeEnum.Movie, CreditTypeEnum.Crew),
                                tvCredits.Casts?.Map(cast.ApiModelId, tvCredits.Id, ContentTypeEnum.Tv, CreditTypeEnum.Cast),
                                tvCredits.Crews?.Map(cast.ApiModelId, tvCredits.Id, ContentTypeEnum.Tv, CreditTypeEnum.Crew)
                            }
                            .Where(list => list != null)
                            .SelectMany(list => list!)
                            .ToList();
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedContentCasts = await Task.WhenAll(tasks);


                    // ذخیره دسته‌ای
                    await _contentCastRepository.BulkInsertIfNotExistAsync(
                        updatedContentCasts
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
