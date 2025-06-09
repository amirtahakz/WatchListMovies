using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public static class MovieMapper
    {
        public static List<Domain.MovieAgg.Movie> Map(this List<PopularMoviesItemApiModelDto> popularMovies)
        {
            var result = new List<Domain.MovieAgg.Movie>();

            foreach (var item in popularMovies)
                result.Add(item.Map());

            return result;
        }

        public static Domain.MovieAgg.Movie Map(this PopularMoviesItemApiModelDto popularMovie)
        {
            var result = new Domain.MovieAgg.Movie()
            {
                Adult = popularMovie.Adult,
                ApiModelId = popularMovie.ApiModelId,
                BackdropPath = popularMovie.BackdropPath,
                OriginalLanguage = popularMovie.OriginalLanguage,
                OriginalTitle = popularMovie.Title,
                Overview = popularMovie.Overview,
                Popularity = popularMovie.Popularity,
                PosterPath = popularMovie.PosterPath,
                ReleaseDate = popularMovie.ReleaseDate,
                Title = popularMovie.Title,
                Video = popularMovie.Video,
                VoteAverage = popularMovie.VoteAverage,
                VoteCount = popularMovie.VoteCount,
                GenreIds = popularMovie.GenreIds,
            };
            return result;
        }

        public static MovieDetail Map(this MovieDetailsApiModelDto movieDetails, Guid movieId)
        {
            var result = new MovieDetail()
            {
                Adult = movieDetails.Adult,
                ApiModelId = movieDetails.ApiModelId,
                BackdropPath = movieDetails.BackdropPath,
                Budget = movieDetails.Budget,
                Homepage = movieDetails.Homepage,
                ImdbId = movieDetails.ImdbId,
                OriginalTitle = movieDetails.OriginalTitle,
                OriginalLanguage = movieDetails.OriginalLanguage,
                Popularity = movieDetails.Popularity,
                PosterPath = movieDetails.PosterPath,
                Overview = movieDetails.Overview,
                ReleaseDate = movieDetails.ReleaseDate,
                Title = movieDetails.Title,
                Revenue = movieDetails.Revenue,
                Status = movieDetails.Status,
                Runtime = movieDetails.Runtime,
                Video = movieDetails.Video,
                Tagline = movieDetails.Tagline,
                VoteCount = movieDetails.VoteCount,
                VoteAverage = movieDetails.VoteAverage,
                MovieId = movieId,
                CollectionApiId = movieDetails.BelongsToCollection == null ? default : movieDetails.BelongsToCollection.ApiModelId
            };

            if (movieDetails.Genres != null)
                result.GenreIds = movieDetails.Genres.Where(g => g.ApiModelId.HasValue).Select(g => g.ApiModelId.Value.ToString()).ToList().AsReadOnly();

            if (movieDetails.SpokenLanguages != null)
                result.LanguageIds = movieDetails.SpokenLanguages.Select(g => g.Iso6391).ToList();

            if (movieDetails.ProductionCompanies != null)
                result.CompanyIds = movieDetails.ProductionCompanies.Where(g => g.ApiModelId.HasValue).Select(g => g.ApiModelId.Value.ToString()).ToList().AsReadOnly();

            if (movieDetails.ProductionCountries != null)
                result.CountryIds = movieDetails.ProductionCountries.Select(g => g.Iso31661).ToList().AsReadOnly();

            return result;
        }

    }
}
