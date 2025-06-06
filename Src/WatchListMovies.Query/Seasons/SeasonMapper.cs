using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Query.Collections.DTOs;
using WatchListMovies.Query.Seasons.DTOs;

namespace WatchListMovies.Query.Seasons
{
    public static class SeasonMapper
    {
        public static SeasonDto Map(this Domain.SeasonAgg.Season season)
        {
            return new SeasonDto()
            {
                AirDate = season.AirDate,
                ApiModelId = season.ApiModelId,
                CreationDate = season.CreationDate,
                EpisodeCount = season.EpisodeCount,
                Id = season.Id,
                Name = season.Name,
                Overview = season.Overview,
                PosterPath = season.PosterPath,
                SeasonNumber = season.SeasonNumber,
                TvApiId = season.TvApiId,
                VoteAverage = season.VoteAverage,
            };
        }

        public static List<SeasonDto> Map(this List<Domain.SeasonAgg.Season> seasons)
        {
            var result = new List<SeasonDto>();

            foreach (var item in seasons)
                result.Add(item.Map());

            return result;
        }
    }
}
