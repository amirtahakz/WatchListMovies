using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public static class MovieMapper
    {
        public static List<Domain.MovieAgg.Movie> Map(this PopularMoviesApiModelDto popularMoviesApiModelDto)
        {
            var result = new List<Domain.MovieAgg.Movie>();

            foreach (var item in popularMoviesApiModelDto.movies)
                result.Add(item.Map());

            return result;
        }

        public static Domain.MovieAgg.Movie Map(this PopularMoviesItemApiModelDto popularMoviesItemApiModelDto)
        {
            var result = new Domain.MovieAgg.Movie()
            {
                Adult = popularMoviesItemApiModelDto.Adult,
                ApiModelId = popularMoviesItemApiModelDto.ApiModelId,
                BackdropPath = popularMoviesItemApiModelDto.BackdropPath,
                OriginalLanguage = popularMoviesItemApiModelDto.OriginalLanguage,
                OriginalTitle = popularMoviesItemApiModelDto.Title,
                Overview = popularMoviesItemApiModelDto.Overview,
                Popularity = popularMoviesItemApiModelDto.Popularity,
                PosterPath = popularMoviesItemApiModelDto.PosterPath,
                ReleaseDate = popularMoviesItemApiModelDto.ReleaseDate,
                Title = popularMoviesItemApiModelDto.Title,
                Video = popularMoviesItemApiModelDto.Video,
                VoteAverage = popularMoviesItemApiModelDto.VoteAverage,
                VoteCount = popularMoviesItemApiModelDto.VoteCount,
                GenreIds = popularMoviesItemApiModelDto.GenreIds
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
            };

            if (movieDetails.Genres != null)
                result.Genres = movieDetails.Genres.Map(result.Id);

            if (movieDetails.SpokenLanguages != null)
                result.SpokenLanguages = movieDetails.SpokenLanguages.Map(result.Id);

            if (movieDetails.ProductionCompanies != null)
                result.ProductionCompanies = movieDetails.ProductionCompanies.Map(result.Id);

            if (movieDetails.ProductionCountries != null)
                result.ProductionCountries = movieDetails.ProductionCountries.Map(result.Id);



            if (movieDetails.BelongsToCollection != null)
            {
                result.BelongsToCollection = new Domain.MovieAgg.ValueObjects.BelongsToCollectionValueObject()
                {
                    BackdropPath = movieDetails.BelongsToCollection.BackdropPath,
                    PosterPath = movieDetails.BelongsToCollection.PosterPath,
                    ApiModelId = movieDetails.BelongsToCollection.ApiModelId,
                    Name = movieDetails.BelongsToCollection.Name,
                    MediaId = result.Id,
                };
            }

            return result;
        }

        public static List<MovieKeyYoutubeTrailer> Map(this MovieKeyYoutubeTrailersItem movieKeyYoutubeTrailers, Guid movieDetailId)
        {
            var result = new List<MovieKeyYoutubeTrailer>();
            var model = new MovieKeyYoutubeTrailer()
            {
                Name = movieKeyYoutubeTrailers.Name,
                ApiModelId = movieKeyYoutubeTrailers.Id,
                Iso31661 = movieKeyYoutubeTrailers.Iso31661,
                Iso6391 = movieKeyYoutubeTrailers.Iso6391,
                Key = movieKeyYoutubeTrailers.Key,
                MediaId = movieDetailId,
                Official = movieKeyYoutubeTrailers.Official,
                PublishedAt = movieKeyYoutubeTrailers.PublishedAt,
                Site = movieKeyYoutubeTrailers.Site,
                Size = movieKeyYoutubeTrailers.Size,
                Type = movieKeyYoutubeTrailers.Type,
            };
            result.Add(model);

            return result;
        }


        public static MovieCast Map(this MovieAndTvCastsItemApiModelDto cast, Guid movieDetailId)
        {
            var result = new MovieCast()
            {
                Adult = cast.Adult,
                ApiModelId = cast.Id,
                CastId = cast.CastId,
                Character = cast.Character,
                CreditId = cast.CreditId,
                Gender = cast.Gender,
                KnownForDepartment = cast.KnownForDepartment,
                MovieDetailsId = movieDetailId,
                Name = cast.Name,
                Order = cast.Order,
                OriginalName = cast.OriginalName,
                Popularity = cast.Popularity,
                ProfilePath = cast.ProfilePath,

            };

            return result;
        }

        public static List<MovieCast> Map(this List<MovieAndTvCastsItemApiModelDto> casts, Guid movieDetailId)
        {
            var result = new List<MovieCast>();

            foreach (var cast in casts)
                result.Add(cast.Map(movieDetailId));

            return result;
        }

        public static MovieCrew Map(this MovieAndTvCrewsItemApiModelDto crew, Guid movieDetailId)
        {
            var result = new MovieCrew()
            {
                Adult = crew.Adult,
                ApiModelId = crew.Id,
                CreditId = crew.CreditId,
                Gender = crew.Gender,
                KnownForDepartment = crew.KnownForDepartment,
                MovieDetailsId = movieDetailId,
                Name = crew.Name,
                OriginalName = crew.OriginalName,
                Popularity = crew.Popularity,
                ProfilePath = crew.ProfilePath,
                Department = crew.Department,
                Job = crew.Job,
            };

            return result;
        }

        public static List<MovieCrew> Map(this List<MovieAndTvCrewsItemApiModelDto> crews, Guid movieDetailId)
        {
            var result = new List<MovieCrew>();

            foreach (var crew in crews)
                result.Add(crew.Map(movieDetailId));

            return result;
        }
    }
}
