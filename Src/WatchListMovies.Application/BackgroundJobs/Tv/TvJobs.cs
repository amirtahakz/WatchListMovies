using AutoMapper;
using MediatR;
using WatchListMovies.Application.IExternalApiServices.Tv;
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
                //    apiTvs.Results.AddRange(data.Results);
                //}
                for (var page = 2; page <= 2; page++)
                {
                    var data = await _tvApiService.GetPopularTvs(page);
                    apiTvs.Results.AddRange(data.Results);
                }
                var isDeleted = await _tvRepository.DeleteAllAsync();
                await _tvRepository.Save();
                if (isDeleted)
                {
                    await _tvRepository.AddRange(apiTvs.Map());
                    await _tvRepository.Save();
                }
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
    }
}
