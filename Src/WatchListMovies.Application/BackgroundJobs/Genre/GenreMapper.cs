using WatchListMovies.Application.IExternalApiServices.Genre.ApiModelDTOs;
using WatchListMovies.Domain.GenreAgg.Enums;

namespace WatchListMovies.Application.BackgroundJobs.Genre
{
    public static class GenreMapper
    {
        public static List<Domain.GenreAgg.Genre> Map(this GetGenresApiModelDto model , GenreType genreType)
        {
            var result = new List<Domain.GenreAgg.Genre>();

            foreach (var item in model.Genres)
                result.Add(item.Map(genreType));

            return result;
        }

        public static Domain.GenreAgg.Genre Map(this GetGenresItemApiModelDto genre, GenreType genreType)
        {
            var model = new Domain.GenreAgg.Genre()
            {
                ApiModelId = genre.Id,
                GenreType = genreType,
                Name = genre.Name,
            };

            return model;
        }


    }
}
