using WatchListMovies.Common.Domain;
using WatchListMovies.Domain._Shared.ValueObjects;

namespace WatchListMovies.Domain.CastAgg.ValueObjects
{
    public class CastKnownForValueObject : BaseValueObject
    {
        public CastKnownForValueObject()
        {

        }

        public CastKnownForValueObject(
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
            DateTime? releaseDate,
            bool? video,
            double? voteAverage,
            long? voteCount,
            List<GenreValueObject>? castKnownForGenreIds)
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
        public DateTime? ReleaseDate { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public List<GenreValueObject>? CastKnownForGenreIds { get; set; }
    }
}
