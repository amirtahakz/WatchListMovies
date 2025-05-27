using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.ListAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Query.Lists.DTOs;
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

            };
        }
    }
}
