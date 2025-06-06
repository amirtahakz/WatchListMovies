using AutoMapper;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Cast
{
    public class CastJobs
    {
        private readonly ICastApiService _castApiService;
        private readonly ICastRepository _castRepository;
        private readonly IMapper _mapper;

        public CastJobs(
            ICastApiService castApiService,
            ICastRepository castRepository,
            IMapper mapper)
        {
            _castApiService = castApiService;
            _castRepository = castRepository;
            _mapper = mapper;
        }

        public async Task SyncPopularCasts()
        {
            try
            {
                var apiCasts = await _castApiService.GetPopularCasts(1);

                for (var page = 2; page <= apiCasts.TotalPages; page++)
                {
                    var data = await _castApiService.GetPopularCasts(page);
                    foreach (var item in data.Casts)
                    {
                        if (!apiCasts.Casts.Any(v => v.Id == item.Id))
                            apiCasts.Casts.Add(item);
                    }
                }

                await _castRepository.AddRangeIfNotExistAsync(apiCasts.Map());
                await _castRepository.Save();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SyncCastDetails()
        {

            try
            {
                var casts = await _castRepository.GetAllAsync();
                if (casts.Any())
                {
                    foreach (var cast in casts)
                    {
                        var apiCastDetails = await _castApiService.GetCastDetails(cast.ApiModelId ?? default);
                        cast.CastDetails = apiCastDetails.Map(cast.Id);
                        await _castRepository.Save();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncCastExternalIds()
        {

            try
            {
                var casts = await _castRepository.GetAllAsync();
                if (casts.Any())
                {
                    foreach (var cast in casts)
                    {
                        var apiCastDetails = await _castApiService.GetCastExternalIds(cast.ApiModelId ?? default);
                        cast.CastExternalId = apiCastDetails.Map(cast.Id);
                        await _castRepository.Save();
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
