using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Common.Query.Filter;
using WatchListMovies.Domain.ListAgg.Enums;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Query.Movies.DTOs
{
    public class MovieDto : BaseDto
    {
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public MovieDetail? MovieDetails { get; set; }
    }

    public class MovieFilterData : BaseDto
    {
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public MovieDetail? MovieDetails { get; set; }
    }

    public class MovieFilterParams : BaseFilterParam
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public MovieDetail? MovieDetails { get; set; }
    }
    public class MovieFilterResult : BaseFilter<MovieFilterData, MovieFilterParams>
    {

    }
}
