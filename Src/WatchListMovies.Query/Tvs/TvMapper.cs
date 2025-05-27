using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs
{
    public static class TvMapper
    {
        public static TvDto Map(this Tv tv)
        {
            return new TvDto()
            {
                Id = tv.Id,
                CreationDate = tv.CreationDate,
                ApiModelId = tv.ApiModelId,
                Adult = tv.Adult,
                BackdropPath = tv.BackdropPath,
                OriginalLanguage = tv.OriginalLanguage,
                Overview = tv.Overview,
                Popularity = tv.Popularity,
                PosterPath = tv.PosterPath,
                VoteAverage = tv.VoteAverage,
                VoteCount = tv.VoteCount,
                FirstAirDate = tv.FirstAirDate,
                Name = tv.Name,
                OriginalName = tv.OriginalName,
                TvDetail = tv.TvDetail,
                

            };
        }
    }
}
