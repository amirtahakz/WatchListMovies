using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg
{
    public class Tv : BaseEntity
    {
        public Tv()
        {
            
        }

        public Tv(bool? adult,
            string? backdropPath,
            long? apiModelId,
            string? originalLanguage,
            string? originalName,
            string? overview,
            double? popularity,
            string? posterPath,
            string? firstAirDate,
            string? name,
            double? voteAverage,
            long? voteCount,
            TvDetail tvDetail)
        {
            Adult = adult;
            BackdropPath = backdropPath;
            ApiModelId = apiModelId;
            OriginalLanguage = originalLanguage;
            OriginalName = originalName;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            FirstAirDate = firstAirDate;
            Name = name;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            TvDetail = tvDetail;
        }

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
}
