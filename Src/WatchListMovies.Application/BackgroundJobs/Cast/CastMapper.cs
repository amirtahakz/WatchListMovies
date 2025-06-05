using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Domain.CastAgg;

namespace WatchListMovies.Application.BackgroundJobs.Cast
{
    public static class CastMapper
    {
        public static List<Domain.CastAgg.Cast> Map(this PopularCastsApiModelDto cast)
        {
            var result = new List<Domain.CastAgg.Cast>();
            foreach (var castItem in cast.Casts)
            {
                var model = new Domain.CastAgg.Cast()
                {
                    Adult = castItem.Adult,
                    ApiModelId = castItem.Id,
                    Popularity = castItem.Popularity,
                    Gender = castItem.Gender,
                    KnownForDepartment = castItem.KnownForDepartment,
                    Name = castItem.Name,
                    OriginalName = castItem.OriginalName,
                    ProfilePath = castItem.ProfilePath,
                };

                if (castItem.KnownFor != null)
                    model.MovieKnownForIds = castItem.Id.HasValue? new List<string> { castItem.Id.Value.ToString() } : null;

                result.Add(model);
            }
            return result;
        }

        public static CastDetail Map(this CastDetailsApiModelDto castDetails, Guid castId)
        {
            var result = new CastDetail()
            {
                Adult = castDetails.Adult,
                ApiModelId = castDetails.Id,
                Homepage = castDetails.Homepage,
                ImdbId = castDetails.ImdbId,
                Popularity = castDetails.Popularity,
                Biography = castDetails.Biography,
                Birthday = castDetails.Birthday,
                CastId = castId,
                Deathday = castDetails.Deathday,
                Gender = castDetails.Gender,
                KnownForDepartment = castDetails.KnownForDepartment,
                Name = castDetails.Name,
                PlaceOfBirth = castDetails.PlaceOfBirth,
                ProfilePath = castDetails.ProfilePath,
                CastAlsoKnownAss = castDetails.AlsoKnownAs

            };

            return result;
        }

        public static CastExternalId Map(this CastExternalIdsApiModelDto castExternalIds, Guid castId)
        {
            var result = new CastExternalId()
            {
                ApiModelId = castExternalIds.Id,
                CastId = castId,
                FacebookId = castExternalIds.FacebookId,
                FreebaseId = castExternalIds.FreebaseId,
                FreebaseMid = castExternalIds.FreebaseMid,
                ImdbId = castExternalIds.ImdbId,
                InstagramId = castExternalIds.InstagramId,
                TiktokId = castExternalIds.TiktokId,
                TvrageId = castExternalIds.TvrageId,
                TwitterId = castExternalIds.TwitterId,
                WikidataId = castExternalIds.WikidataId,
                YoutubeId = castExternalIds.YoutubeId,

            };

            return result;
        }

        
    }
}
