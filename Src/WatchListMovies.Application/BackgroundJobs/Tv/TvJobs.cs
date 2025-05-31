using AutoMapper;
using MediatR;
using System.Collections.Generic;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Tv
{
    public class TvJobs
    {
        private readonly IMapper _mapper;
        private readonly ITvRepository _tvRepository;
        private readonly ITvApiService _tvApiService;

        public TvJobs(IMapper mapper, ITvRepository tvRepository, ITvApiService tvApiService)
        {
            _mapper = mapper;
            _tvRepository = tvRepository;
            _tvApiService = tvApiService;
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
                    apiTvs.Tvs.AddRange(data.Tvs);
                }

                await _tvRepository.AddRangeIfNotExistAsync(apiTvs.Map());
                await _tvRepository.Save();
                
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SyncTvDetails()
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
                        await _tvRepository.Save();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncCastsAndCrewsOfTv()
        {

            try
            {
                var tvs = await _tvRepository.GetAllAsync();
                if (tvs.Count() != 0)
                {
                    foreach (var tv in tvs)
                    {
                        var apiCastsAndCrewsOfTv = await _tvApiService.GetCastsAndCrewsOfTv(tv.ApiModelId ?? default);

                        if (apiCastsAndCrewsOfTv.Casts != null)
                            tv.TvDetail.Casts.AddRange(apiCastsAndCrewsOfTv.Casts.Map(tv.TvDetail.Id));


                        if (apiCastsAndCrewsOfTv.Crews != null)
                            tv.TvDetail.Crews.AddRange(apiCastsAndCrewsOfTv.Crews.Map(tv.TvDetail.Id));

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
