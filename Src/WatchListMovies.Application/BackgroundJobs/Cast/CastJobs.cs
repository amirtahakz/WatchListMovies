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
                var apiMovies = await _castApiService.GetPopularCasts(1);

                //for (var page = 1; page <= apiMovies.TotalPages; page++)
                //{
                //    var data = await _castApiService.GetPopularCasts(page);
                //    apiMovies.PopularTvsItemApiModelDto.AddRange(data.PopularTvsItemApiModelDto);
                //}
                for (var page = 2; page <= 2; page++)
                {
                    var data = await _castApiService.GetPopularCasts(page);
                    apiMovies.Results.AddRange(data.Results);
                }
                var isDeleted = await _castRepository.DeleteAllAsync();
                await _castRepository.Save();
                if (isDeleted)
                {
                    await _castRepository.AddRange(apiMovies.Map());
                    await _castRepository.Save();
                }

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
                if (casts.Count() != 0)
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
                if (casts.Count() != 0)
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

        public async Task SyncCastImages()
        {

            try
            {
                var casts = await _castRepository.GetAllAsync();
                if (casts.Count() != 0)
                {
                    foreach (var cast in casts)
                    {
                        var apiCastImages = await _castApiService.GetCastImages(cast.ApiModelId ?? default);
                        cast.CastImages = apiCastImages.Map(cast.Id);
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
