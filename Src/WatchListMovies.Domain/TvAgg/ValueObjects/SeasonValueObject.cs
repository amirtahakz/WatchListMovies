using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg.ValueObjects
{
    public class SeasonValueObject : BaseValueObject
    {
        public SeasonValueObject()
        {

        }

        public SeasonValueObject(
            Guid ParrentId,
            long? apiModelId,
            string? name,
            string? overview,
            long? episodeCount,
            long? seasonNumber,
            DateTime? airDate,
            string? posterPath,
            float? voteAverage)
        {
            ApiModelId = apiModelId;
            Name = name;
            Overview = overview;
            EpisodeCount = episodeCount;
            SeasonNumber = seasonNumber;
            AirDate = airDate;
            PosterPath = posterPath;
            VoteAverage = voteAverage;
            ParrentId = ParrentId;
        }
        public Guid? ParrentId { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? Overview { get; set; }
        public long? EpisodeCount { get; set; }
        public long? SeasonNumber { get; set; }
        public DateTime? AirDate { get; set; }
        public string? PosterPath { get; set; }
        public float? VoteAverage { get; set; }

    }

}
