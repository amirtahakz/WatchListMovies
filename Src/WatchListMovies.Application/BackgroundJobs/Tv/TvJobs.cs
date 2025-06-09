using AutoMapper;
using MediatR;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Tv
{
    public class TvJobs
    {
        private readonly ITvRepository _tvRepository;
        private readonly ITvApiService _tvApiService;
        private readonly PagesCountForGettingDataTest _pagesCountForGettingDataTest;

        public TvJobs(ITvRepository tvRepository, ITvApiService tvApiService , IOptions<PagesCountForGettingDataTest> pagesCountForGettingDataTest)
        {
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
            _pagesCountForGettingDataTest = pagesCountForGettingDataTest.Value;
        }

        public async Task SyncPopularTvs()
        {
            try
            {
                for (var page = 1; ; page++)
                {
                    if (_pagesCountForGettingDataTest.TvPageCount != 0 && page == _pagesCountForGettingDataTest.TvPageCount)
                        break;

                    var data = await _tvApiService.GetPopularTvs(page);
                    if (data == null || data.Tvs == null || !data.Tvs.Any()) break;

                    await _tvRepository.BulkInsertIfNotExistAsync(data.Tvs.Map());

                }

            }
            catch (Exception)
            {
                throw ;
            }
        }

        public async Task SyncTvDetails()
        {

            try
            {
                const int batchSize = 200;
                long totalCount = await _tvRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var tvs = await _tvRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = tvs.Select(async tv =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _tvApiService.GetTvDetails(tv.ApiModelId);
                            tv.TvDetail = apiDetails.Map(tv.Id);
                            return tv;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvs = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _tvRepository.BulkInsertOrUpdateAsync(updatedTvs.ToList());
                }
            }
            catch (Exception)
            {
                throw;
            }

        }

        
    }
}
