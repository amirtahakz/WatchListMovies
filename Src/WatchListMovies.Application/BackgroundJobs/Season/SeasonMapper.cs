using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;

namespace WatchListMovies.Application.BackgroundJobs.Season
{
    public static class SeasonMapper
    {
        public static Domain.SeasonAgg.Season Map(this SeasonApiModelDto season , long? tvApiId)
        {
            var model = new Domain.SeasonAgg.Season()
            {
                AirDate = season.AirDate,
                ApiModelId = season.Id,
                EpisodeCount = season.EpisodeCount,
                Name = season.Name,
                Overview = season.Overview,
                PosterPath = season.PosterPath,
                SeasonNumber = season.SeasonNumber,
                VoteAverage = season.VoteAverage,
                TvApiId = tvApiId ?? default,
            };
            return model;
        }

        public static List<Domain.SeasonAgg.Season> Map(this List<SeasonApiModelDto> seasons, long? tvApiId)
        {
            var result = new List<Domain.SeasonAgg.Season>();

            foreach ( var item in seasons)
                result.Add(item.Map(tvApiId));

            return result;
        }
    }
}
