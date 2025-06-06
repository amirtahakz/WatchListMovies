using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.TvAgg.Enums;

namespace WatchListMovies.Domain.EpisodeAgg
{
    public class Episode : BaseEntity
    {
        public Episode()
        {
            
        }
        public Episode(
            long? tvApiId,
            long? seasonApiId,
            long? apiModelId,
            string? name,
            string? overview,
            float? voteAverage,
            long? voteCount,
            DateTime? airDate,
            long? episodeNumber,
            string? episodeType,
            long? seasonNumber,
            string? stillPath)
        {
            TvApiId = tvApiId;
            SeasonApiId = seasonApiId;
            ApiModelId = apiModelId;
            Name = name;
            Overview = overview;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            AirDate = airDate;
            EpisodeNumber = episodeNumber;
            EpisodeType = episodeType;
            SeasonNumber = seasonNumber;
            StillPath = stillPath;
        }

        public long? TvApiId { get; set; }
        public long? SeasonApiId { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? Overview { get; set; }
        public float? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public DateTime? AirDate { get; set; }
        public long? EpisodeNumber { get; set; }
        public string? EpisodeType { get; set; }
        public long? SeasonNumber { get; set; }
        public string? StillPath { get; set; }
    }
}
