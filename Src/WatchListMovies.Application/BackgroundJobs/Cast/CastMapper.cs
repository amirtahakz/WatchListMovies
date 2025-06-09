using WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs;
using WatchListMovies.Domain.CastAgg;

namespace WatchListMovies.Application.BackgroundJobs.Cast
{
    public static class CastMapper
    {
        public static List<Domain.CastAgg.Cast> Map(this List<PopularCastDetailsItemApiModelDto> casts)
        {
            var result = new List<Domain.CastAgg.Cast>();

            foreach (var cast in casts)
                result.Add(cast.Map());

            return result;
        }

        public static Domain.CastAgg.Cast Map(this PopularCastDetailsItemApiModelDto cast)
        {
            var model = new Domain.CastAgg.Cast()
            {
                Adult = cast.Adult,
                ApiModelId = cast.Id,
                Popularity = cast.Popularity,
                Gender = cast.Gender,
                KnownForDepartment = cast.KnownForDepartment,
                Name = cast.Name,
                OriginalName = cast.OriginalName,
                ProfilePath = cast.ProfilePath,
            };

            if (cast.KnownFor != null)
                model.MovieKnownForIds = cast.Id.HasValue ? new List<string> { cast.Id.Value.ToString() } : null;

            return model;
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
