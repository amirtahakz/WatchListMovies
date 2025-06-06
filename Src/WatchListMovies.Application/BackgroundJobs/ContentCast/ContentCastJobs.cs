using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.ContentCastAgg.Enums;
using WatchListMovies.Domain.ContentCastAgg.Repository;

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
                var casts = await _castRepository.GetAllAsNoTrackingAsync();
                if (casts.Any())
                {
                    foreach (var cast in casts)
                    {
                        var tvCredits = await _castApiService.GetTvCreditsOfCast(cast.ApiModelId);
                        var movieCredits = await _castApiService.GetMovieCreditsOfCast(cast.ApiModelId);

                        //Tv Cast
                        if (tvCredits.Casts != null)
                        {
                            foreach (var castTvCreditsItem in tvCredits.Casts)
                            {
                                await _contentCastRepository.AddIfNotExistAsync(new Domain.ContentCastAgg.ContentCast()
                                {
                                    CastApiModelId = cast.ApiModelId,
                                    ContentType = ContentTypeEnum.Tv,
                                    CreditType = CreditTypeEnum.Cast,
                                    ContentApiModelId = cast.ApiModelId,
                                    Character = castTvCreditsItem?.Character ?? default,
                                    Department = castTvCreditsItem?.Department ?? default,
                                    Job = castTvCreditsItem?.Job ?? default,
                                    CreditId = castTvCreditsItem.CreditId,
                                });
                            }
                        }

                        //Tv Crew
                        if (tvCredits.Crews != null)
                        {
                            foreach (var crewTvCreditsItem in tvCredits.Crews)
                            {
                                await _contentCastRepository.AddIfNotExistAsync(new Domain.ContentCastAgg.ContentCast()
                                {
                                    CastApiModelId = cast.ApiModelId,
                                    ContentType = ContentTypeEnum.Tv,
                                    CreditType = CreditTypeEnum.Crew,
                                    ContentApiModelId = cast.ApiModelId,
                                    Character = crewTvCreditsItem?.Character ?? default,
                                    Department = crewTvCreditsItem?.Department ?? default,
                                    Job = crewTvCreditsItem?.Job ?? default,
                                    CreditId = crewTvCreditsItem.CreditId,
                                });
                            }
                        }

                        //Movie Cast
                        if (movieCredits.Casts != null)
                        {
                            foreach (var castMovieCreditsItem in movieCredits.Casts)
                            {
                                await _contentCastRepository.AddIfNotExistAsync(new Domain.ContentCastAgg.ContentCast()
                                {
                                    CastApiModelId = cast.ApiModelId,
                                    ContentType = ContentTypeEnum.Movie,
                                    CreditType = CreditTypeEnum.Cast,
                                    ContentApiModelId = cast.ApiModelId,
                                    Character = castMovieCreditsItem?.Character ?? default,
                                    Department = castMovieCreditsItem?.Department ?? default,
                                    Job = castMovieCreditsItem?.Job ?? default,
                                    CreditId = castMovieCreditsItem.CreditId,
                                });
                            }
                        }

                        //Movie Crew
                        if (movieCredits.Crews != null)
                        {
                            foreach (var crewMovieCreditsItem in movieCredits.Crews)
                            {
                                await _contentCastRepository.AddIfNotExistAsync(new Domain.ContentCastAgg.ContentCast()
                                {
                                    CastApiModelId = cast.ApiModelId,
                                    ContentType = ContentTypeEnum.Movie,
                                    CreditType = CreditTypeEnum.Crew,
                                    ContentApiModelId = cast.ApiModelId,
                                    Character = crewMovieCreditsItem?.Character ?? default,
                                    Department = crewMovieCreditsItem?.Department ?? default,
                                    Job = crewMovieCreditsItem?.Job ?? default,
                                    CreditId = crewMovieCreditsItem.CreditId,
                                });
                            }
                        }

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
