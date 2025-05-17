using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Common.Query.Filter;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Query.Tvs.DTOs
{
    public class TvDto : BaseDto
    {
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? FirstAirDate { get; set; }
        public string? Name { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public TvDetail? TvDetail { get; set; }
    }

    public class TvFilterData : BaseDto
    {
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? FirstAirDate { get; set; }
        public string? Name { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public TvDetail? TvDetail { get; set; }
    }

    public class TvFilterParams : BaseFilterParam
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? FirstAirDate { get; set; }
        public string? Name { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public TvDetail? TvDetail { get; set; }
    }
    public class TvFilterResult : BaseFilter<TvFilterData, TvFilterParams>
    {

    }
}
