using AutoMapper;
using MediatR;
using System.Collections.Generic;
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
        private readonly ICompanyRepository _companyRepository;

        public TvJobs(ITvRepository tvRepository, ITvApiService tvApiService, ICompanyRepository companyRepository)
        {
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
            _companyRepository = companyRepository;
        }

        public async Task SyncPopularTvs()
        {
            try
            {
                var apiTvs = await _tvApiService.GetPopularTvs(1);

                //for (var page = 1; page <= apiTvs.TotalPages; page++)
                //{
                //    var data = await _movieApiService.GetPopularMovies(page);
                //    apiTvs.PopularTvsItemApiModelDto.AddRange(data.PopularTvsItemApiModelDto);
                //}
                for (var page = 2; page <= 2; page++)
                {
                    var data = await _tvApiService.GetPopularTvs(page);
                    foreach (var item in data.Tvs)
                    {
                        if (!apiTvs.Tvs.Any(v => v.Id == item.Id))
                            apiTvs.Tvs.Add(item);
                    }
                    
                }

                await _tvRepository.AddRangeIfNotExistAsync(apiTvs.Map());
                await _tvRepository.Save();
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SyncTvDetailsAndCompanies()
        {

            try
            {
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Count() != 0)
                {
                    foreach (var tv in tvs)
                    {
                        var apiTvDetails = await _tvApiService.GetTvDetails(tv.ApiModelId ?? default);
                        tv.TvDetail = apiTvDetails.Map(tv.Id);
                        await _companyRepository.AddRangeIfNotExistAsync(apiTvDetails.ProductionCompanies.Map());
                        await _tvRepository.Save();
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
