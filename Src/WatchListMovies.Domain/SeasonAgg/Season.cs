using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.SeasonAgg
{
    public class Season : BaseEntity
    {
        public Season()
        {
            
        }
        public Season(
            long? apiModelId,
            long? tvApiId,
            string? name,
            string? overview,
            long? episodeCount,
            long? seasonNumber,
            DateTime? airDate,
            string? posterPath,
            float? voteAverage)
        {
            ApiModelId = apiModelId;
            TvApiId = tvApiId;
            Name = name;
            Overview = overview;
            EpisodeCount = episodeCount;
            SeasonNumber = seasonNumber;
            AirDate = airDate;
            PosterPath = posterPath;
            VoteAverage = voteAverage;
        }

        public long? ApiModelId { get; set; }
        public long? TvApiId { get; set; }
        public string? Name { get; set; }
        public string? Overview { get; set; }
        public long? EpisodeCount { get; set; }
        public long? SeasonNumber { get; set; }
        public DateTime? AirDate { get; set; }
        public string? PosterPath { get; set; }
        public float? VoteAverage { get; set; }
    }
}
