using WatchListMovies.Application.IExternalApiServices.Genre.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Genre
{
    public interface IGenreApiService
    {
        public Task<GetGenresApiModelDto> GetMovieGenres();

        public Task<GetGenresApiModelDto> GetTvGenres();
    }
}
