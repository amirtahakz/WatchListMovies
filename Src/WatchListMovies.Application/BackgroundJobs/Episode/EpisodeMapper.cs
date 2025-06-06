using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Season.ApiModelDTOs;

namespace WatchListMovies.Application.BackgroundJobs.Episode
{
    public static class EpisodeMapper
    {
        public static Domain.EpisodeAgg.Episode Map(this GetSeasonDetailsEpisodeApiModelDto requestModel , long seasonApiId , long tvApiId)
        {
            var model = new Domain.EpisodeAgg.Episode() 
            {
                AirDate = requestModel.AirDate,
                ApiModelId = requestModel.Id,
                EpisodeNumber = requestModel.EpisodeNumber,
                EpisodeType = requestModel.EpisodeType,
                Name = requestModel.Name,
                Overview = requestModel.Overview,
                SeasonApiId = seasonApiId,
                SeasonNumber = seasonApiId,
                StillPath = requestModel.StillPath,
                TvApiId = tvApiId, 
                VoteAverage = requestModel.VoteAverage,
                VoteCount = requestModel.VoteCount,
            };
            return model;
        }

        public static List<Domain.EpisodeAgg.Episode> Map(this List<GetSeasonDetailsEpisodeApiModelDto> requestModels, long seasonApiId, long tvApiId)
        {
            var result = new List<Domain.EpisodeAgg.Episode>();

            foreach (var item in requestModels)
                result.Add(item.Map(seasonApiId, tvApiId));

            return result;
        }
    }
}
