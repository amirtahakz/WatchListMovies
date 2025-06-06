using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Companies.DTOs;

namespace WatchListMovies.Query.Episodes.DTOs
{
    public class EpisodeDto : BaseDto
    {
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

    public class EpisodeFilterParams : BaseFilterParam
    {
        public List<long>? TvApiIds { get; set; }
        public List<long>? SeasonApiIds { get; set; }
        public List<long>? ApiModelIds { get; set; }
        public string? Name { get; set; }
        public DateTime? StartAirDate { get; set; }
        public DateTime? EndAirDate { get; set; }
    }
    public class EpisodeFilterResult : BaseFilter<EpisodeDto, EpisodeFilterParams>
    {

    }
}
