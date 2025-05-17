using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Domain.MovieAgg;
using ProductionCompany = WatchListMovies.Domain._Shared.ValueObjects.ProductionCompany;
using ProductionCountry = WatchListMovies.Domain._Shared.ValueObjects.ProductionCountry;
using SpokenLanguage = WatchListMovies.Domain._Shared.ValueObjects.SpokenLanguage;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public static class MovieMapper
    {
        public static List<Domain.MovieAgg.Movie> Map(this PopularMoviesApiModelDto movie)
        {
            var result = new List<Domain.MovieAgg.Movie>();
            foreach (var item in movie.Results)
            {
                var model = new Domain.MovieAgg.Movie()
                {
                    Adult = item.Adult,
                    ApiModelId = item.ApiModelId,
                    BackdropPath = item.BackdropPath,
                    OriginalLanguage = item.OriginalLanguage,
                    OriginalTitle = item.Title,
                    Overview = item.Overview,
                    Popularity = item.Popularity,
                    PosterPath = item.PosterPath,
                    ReleaseDate = item.ReleaseDate,
                    Title = item.Title,
                    Video = item.Video,
                    VoteAverage = item.VoteAverage,
                    VoteCount = item.VoteCount,
                };
                result.Add(model);
            }
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
            };
            if (movieDetails.Genres != null)
            {
                foreach (var item in movieDetails.Genres)
                {
                    result.Genres = new List<Domain._Shared.ValueObjects.Genre>()
                    {
                        new ()
                        {
                            ApiModelId = item.ApiModelId,
                            Name = item.Name,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (movieDetails.SpokenLanguages != null)
            {
                foreach (var item in movieDetails.SpokenLanguages)
                {
                    result.SpokenLanguages = new List<SpokenLanguage>()
                    {
                        new ()
                        {
                            Name = item.Name,
                            EnglishName = item.EnglishName,
                            Iso6391 = item.Iso6391,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (movieDetails.ProductionCompanies != null)
            {
                foreach (var item in movieDetails.ProductionCompanies)
                {
                    result.ProductionCompanies = new List<ProductionCompany>()
                    {
                        new ()
                        {
                            Name = item.Name,
                            LogoPath = item.LogoPath,
                            OriginCountry = item.OriginCountry,
                            ApiModelId = item.ApiModelId,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (movieDetails.ProductionCountries != null)
            {
                foreach (var item in movieDetails.ProductionCountries)
                {
                    result.ProductionCountries = new List<ProductionCountry>()
                    {
                        new ()
                        {
                            Name = item.Name,
                            Iso31661 = item.Iso31661,
                            MediaId = result.Id
                        }
                    };
                }
            }

            if (movieDetails.BelongsToCollection != null)
            {
                result.BelongsToCollection = new Domain.MovieAgg.ValueObjects.BelongsToCollection()
                {
                    BackdropPath = movieDetails.BelongsToCollection.BackdropPath,
                    PosterPath = movieDetails.BelongsToCollection.PosterPath,
                    ApiModelId = movieDetails.BelongsToCollection.ApiModelId,
                    Name = movieDetails.BelongsToCollection.Name,
                    MovieDetailId = result.Id,
                };
            }

            return result;
        }
    }
}
