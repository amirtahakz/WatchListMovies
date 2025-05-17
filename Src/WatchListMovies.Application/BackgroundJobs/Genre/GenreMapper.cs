using WatchListMovies.Application.IExternalApiServices.Genre.ApiModelDTOs;

namespace WatchListMovies.Application.BackgroundJobs.Genre
{
    public static class GenreMapper
    {
        public static List<Domain.GenreAgg.Genre> Map(this GetGenresApiModelDto genre , Domain.GenreAgg.Enums.GenreType genreType)
        {
            var result = new List<Domain.GenreAgg.Genre>();
            foreach (var item in genre.Genres)
            {
                var model = new Domain.GenreAgg.Genre()
                {
                    ApiModelId = item.Id,
                    GenreType = genreType,
                    Name = item.Name,
                };
                result.Add(model);
            }
            return result;
        }

        
    }
}
