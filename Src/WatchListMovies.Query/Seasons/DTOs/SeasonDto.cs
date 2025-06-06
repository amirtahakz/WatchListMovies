using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Collections.DTOs;

namespace WatchListMovies.Query.Seasons.DTOs
{
    public class SeasonDto : BaseDto
    {
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

    public class SeasonFilterParams : BaseFilterParam
    {
        public long? ApiModelId { get; set; }
        public List<long>? TvApiIds { get; set; }
        public string? Name { get; set; }  
        public DateTime? StartAirDate { get; set; }
        public DateTime? EndAirDate { get; set; }
    }
    public class SeasonFilterResult : BaseFilter<SeasonDto, SeasonFilterParams>
    {

    }
}
