using WatchListMovies.Query.Genre.DTOs;

namespace WatchListMovies.Query.Genre
{
    public static class GenreMapper
    {
        public static GenreDto Map(this Domain.GenreAgg.Genre genre)
        {
            return new GenreDto()
            {
                ApiModelId = genre.ApiModelId,
                GenreType = genre.GenreType,
                Name = genre.Name,
                CreationDate = genre.CreationDate,
                Id = genre.Id
            };
        }
    }
}
