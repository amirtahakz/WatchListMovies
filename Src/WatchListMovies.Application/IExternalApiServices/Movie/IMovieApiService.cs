using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Movie
{
    public interface IMovieApiService
    {
        public Task<PopularMoviesApiModelDto> GetPopularMovies(int page = 1);

        public Task<MovieDetailsApiModelDto> GetMovieDetails(long? movieApiId);
        Task<MovieKeyYoutubeTrailersApiModelDto> GetMovieYoutubeTrailerKeys(long? movieApiId);

        Task<ImagesApiModelDto> GetMovieImages(long? movieApiId);
    }
}
