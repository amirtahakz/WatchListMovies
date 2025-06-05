using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Domain.CompanyAgg;
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
                GenreIds = popularMoviesItemApiModelDto.GenreIds,
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
                ParrentId = movieDetailId,
                Official = movieKeyYoutubeTrailers.Official,
                PublishedAt = movieKeyYoutubeTrailers.PublishedAt,
                Site = movieKeyYoutubeTrailers.Site,
                Size = movieKeyYoutubeTrailers.Size,
                Type = movieKeyYoutubeTrailers.Type,
            };
            result.Add(model);

            return result;
        }

    }
}
