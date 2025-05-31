using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.MovieAgg
{
    public class Movie : BaseEntity
    {
        public Movie()
        {
            
        }

        public Movie(
            bool? adult,
            string? backdropPath,
            long? apiModelId,
            string? originalLanguage,
            string? originalTitle,
            string? overview,
            double? popularity,
            string? posterPath,
            DateTime? releaseDate,
            string? title,
            bool? video,
            double? voteAverage,
            int? voteCount,
            IEnumerable<string>? genreIds,
            MovieDetail movieDetails,
            bool? isRecommendedByAdmin= false)
        {
            Adult = adult;
            BackdropPath = backdropPath;
            ApiModelId = apiModelId;
            OriginalLanguage = originalLanguage;
            OriginalTitle = originalTitle;
            Overview = overview;
            Popularity = popularity;
            PosterPath = posterPath;
            ReleaseDate = releaseDate;
            Title = title;
            Video = video;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            GenreIds = genreIds.ToList();
            MovieDetails = movieDetails;
            IsRecommendedByAdmin = isRecommendedByAdmin;
        }

        public void MakeRecommended()
        {
            IsRecommendedByAdmin = true;
        }
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public DateTime? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public bool? IsRecommendedByAdmin { get; set; }
        public IReadOnlyCollection<string>? GenreIds { get; set; }
        public MovieDetail? MovieDetails { get; set; }
    }
}
