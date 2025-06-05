using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices.Company;
using WatchListMovies.Application.IExternalApiServices.Configuration;
using WatchListMovies.Application.IExternalApiServices.Configuration.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Domain.LanguageAgg.Repository;
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

        public async Task SyncCompanies()
        {
            try
            {
                //Movie Companies
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        var apiMovieDetails = await _movieApiService.GetMovieDetails(movie.ApiModelId ?? default);
                        await _companyRepository.AddRangeIfNotExistAsync(apiMovieDetails.ProductionCompanies.Map());
                        await _companyRepository.Save();
                    }
                }

                //Tv Companies
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Any())
                {
                    foreach (var tv in tvs)
                    {
                        var apiTvDetails = await _tvApiService.GetTvDetails(tv.ApiModelId ?? default);
                        await _companyRepository.AddRangeIfNotExistAsync(apiTvDetails.ProductionCompanies.Map());
                        await _companyRepository.Save();
                    }
                }

            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncCompanyDetails()
        {
            try
            {
                var companies = await _companyRepository.GetAllAsync();

                if (companies.Any())
                {
                    foreach (var item in companies)
                    {
                        var companyApi = await _companyApiService.GetCompanyDetails((long)item.ApiModelId);
                        item.CompanyDetail = companyApi.Map(item.Id);
                        await _companyRepository.Save();

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
