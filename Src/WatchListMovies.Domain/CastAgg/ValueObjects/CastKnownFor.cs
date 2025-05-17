using WatchListMovies.Common.Domain;
using WatchListMovies.Domain._Shared.ValueObjects;

namespace WatchListMovies.Domain.CastAgg.ValueObjects
{
    public class CastKnownFor : BaseValueObject
    {
        public CastKnownFor()
        {

        }

        public CastKnownFor(
            Guid castId,
            string? backdropPath,
            long? apiModelId,
            string? title,
            string? originalTitle,
            string? overview,
            string? posterPath,
            string? mediaType,
            bool? adult,
            string? originalLanguage,
            double? popularity,
            string? releaseDate,
            bool? video,
            double? voteAverage,
            long? voteCount,
            List<Genre>? castKnownForGenreIds)
        {
            CastId = castId;
            BackdropPath = backdropPath;
            ApiModelId = apiModelId;
            Title = title;
            OriginalTitle = originalTitle;
            Overview = overview;
            PosterPath = posterPath;
            MediaType = mediaType;
            Adult = adult;
            OriginalLanguage = originalLanguage;
            Popularity = popularity;
            ReleaseDate = releaseDate;
            Video = video;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            CastKnownForGenreIds = castKnownForGenreIds;
        }

        public Guid CastId { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? Title { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public string? PosterPath { get; set; }
        public string? MediaType { get; set; }
        public bool? Adult { get; set; }
        public string? OriginalLanguage { get; set; }
        public double? Popularity { get; set; }
        public string? ReleaseDate { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public List<Genre>? CastKnownForGenreIds { get; set; }
    }
}
