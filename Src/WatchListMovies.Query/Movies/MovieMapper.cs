using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Movies
{
    public static class MovieMapper
    {
        public static MovieDto Map(this Movie movie)
        {
            return new MovieDto()
            {
                Id = movie.Id,
                CreationDate = movie.CreationDate,
                OriginalTitle = movie.OriginalTitle,
                Title = movie.Title,
                ApiModelId = movie.ApiModelId,
                Adult = movie.Adult,
                BackdropPath = movie.BackdropPath,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                Popularity = movie.Popularity,
                PosterPath = movie.PosterPath,
                ReleaseDate = movie.ReleaseDate,
                Video = movie.Video,
                VoteAverage = movie.VoteAverage,
                VoteCount = movie.VoteCount,
                MovieDetails = movie.MovieDetails,
                GenreIds = movie.GenreIds,
                IsRecommendedByAdmin = movie.IsRecommendedByAdmin,
            };
        }

        public static List<MovieDto> Map(this List<Movie> movies)
        {
            var result = new List<MovieDto>();
            foreach (var movie in movies)
            {
                result.Add(movie.Map());
            }
            return result;
        }
    }
}
