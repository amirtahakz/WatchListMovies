using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Video.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Video
{
    public interface IVideoApiService
    {
        Task<GetVideosApiModelDto> GetMovieVideos(long? movieApiId);
        Task<GetVideosApiModelDto> GetTvVideos(long? tvApiId);
    }
}
