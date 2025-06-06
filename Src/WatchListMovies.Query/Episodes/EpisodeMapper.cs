using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.EpisodeAgg;
using WatchListMovies.Query.Companies.DTOs;
using WatchListMovies.Query.Episodes.DTOs;

namespace WatchListMovies.Query.Episodes
{
    public static class EpisodeMapper
    {
        public static EpisodeDto Map(this Episode episode)
        {
            return new EpisodeDto()
            {
               AirDate = episode.AirDate,
               ApiModelId = episode.ApiModelId,
               CreationDate = episode.CreationDate,
               EpisodeNumber = episode.EpisodeNumber,
               EpisodeType = episode.EpisodeType,
               Id = episode.Id,
               Name = episode.Name,
               Overview = episode.Overview,
               SeasonApiId = episode.SeasonApiId,
               SeasonNumber = episode.SeasonNumber,
               StillPath = episode.StillPath,
               TvApiId = episode.TvApiId,
               VoteAverage = episode.VoteAverage,
               VoteCount = episode.VoteCount
            };
        }

        public static List<EpisodeDto> Map(this List<Episode> episodes)
        {
            var result = new List<EpisodeDto>();

            foreach (var item in episodes)
                result.Add(item.Map());

            return result;
        }
    }
}
