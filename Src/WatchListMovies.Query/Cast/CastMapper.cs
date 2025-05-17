using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Query.Cast.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Cast
{
    public static class CastMapper
    {
        public static CastDto Map(this Domain.CastAgg.Cast movie)
        {
            return new CastDto()
            {
                Id = movie.Id,
                CreationDate = movie.CreationDate,
                ApiModelId = movie.ApiModelId,
                Adult = movie.Adult,
                Popularity = movie.Popularity,
                CastKnownFors = movie.CastKnownFors,
                CastDetails = movie.CastDetails,
                CastExternalId = movie.CastExternalId,
                ProfilePath = movie.ProfilePath,
                Gender = movie.Gender,
                KnownForDepartment = movie.KnownForDepartment,
                Name = movie.Name,
                OriginalName = movie.OriginalName

            };
        }


        public static CastFilterData MapFilterData(this Domain.CastAgg.Cast movie)
        {
            return new CastFilterData()
            {
                Id = movie.Id,
                CreationDate = movie.CreationDate,
                ApiModelId = movie.ApiModelId,
                Adult = movie.Adult,
                Popularity = movie.Popularity,
                CastKnownFors = movie.CastKnownFors,
                CastDetails = movie.CastDetails,
                CastExternalId = movie.CastExternalId,
                ProfilePath = movie.ProfilePath,
                Gender = movie.Gender,
                KnownForDepartment = movie.KnownForDepartment,
                Name = movie.Name,
                OriginalName = movie.OriginalName
            };
        }
    }
}
