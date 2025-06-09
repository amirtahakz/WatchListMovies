using WatchListMovies.Application.BackgroundJobs.Collection;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices.Collection;
using WatchListMovies.Application.IExternalApiServices.Company;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Company
{
    public class CompanyJobs
    {
        private readonly ICompanyApiService _companyApiService;
        private readonly ICompanyRepository _companyRepository;
        private readonly ITvRepository _tvRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieApiService _movieApiService;
        private readonly ITvApiService _tvApiService;


        public CompanyJobs(
            ICompanyApiService companyApiService,
            ICompanyRepository companyRepository,
            ITvRepository tvRepository,
            IMovieRepository movieRepository,
            IMovieApiService movieApiService,
            ITvApiService tvApiService)
        {
            _companyApiService = companyApiService;
            _companyRepository = companyRepository;
            _tvRepository = tvRepository;
            _movieRepository = movieRepository;
            _movieApiService = movieApiService;
            _tvApiService = tvApiService;
        }

        public async Task SyncMovieCompanies()
        {
            try
            {
                const int batchSize = 200;
                long totalCount = await _movieRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var movies = await _movieRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = movies.Select(async movie =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _movieApiService.GetMovieDetails(movie.ApiModelId ?? default);
                            return apiDetails;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedMovies = await Task.WhenAll(tasks);


                    // ذخیره دسته‌ای
                    await _companyRepository.BulkInsertIfNotExistAsync(
                        updatedMovies
                        .Where(item => item.ProductionCompanies != null)
                        .SelectMany(m => m.ProductionCompanies) // flatten
                        .Select(c => c.Map()) // تبدیل به domain model یا entity
                        .ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SyncTvCompanies()
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
                            var apiDetails = await _tvApiService.GetTvDetails(tv.ApiModelId ?? default);
                            return apiDetails;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedTvs = await Task.WhenAll(tasks);


                    // ذخیره دسته‌ای
                    await _companyRepository.BulkInsertIfNotExistAsync(
                        updatedTvs
                        .Where(item => item.ProductionCompanies != null)
                        .SelectMany(m => m.ProductionCompanies) // flatten
                        .Select(c => c.Map()) // تبدیل به domain model یا entity
                        .ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }

        public async Task SyncCompanyDetails()
        {
            try
            {
                const int batchSize = 200;
                long totalCount = await _companyRepository.GetCountAsync();

                for (int skip = 0; skip < totalCount; skip += batchSize)
                {
                    var companies = await _companyRepository.GetBatchAsync(skip, batchSize);

                    var semaphore = new SemaphoreSlim(5);

                    // موازی‌سازی دریافت اطلاعات از API با محدودیت همزمانی
                    var tasks = companies.Select(async company =>
                    {
                        await semaphore.WaitAsync();
                        try
                        {
                            var apiDetails = await _companyApiService.GetCompanyDetails(company.ApiModelId ?? default);
                            company.CompanyDetail = apiDetails.Map(company.Id);
                            return company;
                        }
                        finally
                        {
                            semaphore.Release();
                        }
                    });

                    var updatedCollections = await Task.WhenAll(tasks);

                    // ذخیره دسته‌ای
                    await _companyRepository.BulkInsertOrUpdateAsync(updatedCollections.ToList());
                }

            }
            catch (Exception)
            {
                throw;
            }

        }
    }
}
