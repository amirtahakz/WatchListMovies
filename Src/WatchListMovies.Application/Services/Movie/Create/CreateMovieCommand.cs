using WatchListMovies.Common.Application;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Application.Services.Movie.Create
{
    public class CreateMovieCommand : IBaseCommand<Guid>
    {
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
