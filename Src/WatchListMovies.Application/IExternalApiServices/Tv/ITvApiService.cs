using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.IExternalApiServices.Tv.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Tv
{
    public interface ITvApiService
    {
        Task<PopularTvsApiModelDto> GetPopularTvs(int page = 1);

        Task<TvDetailsApiModelDto> GetTvDetails(long? tvApiId);
        Task<GetCastsAndCrewsOfMovieAndTvApiModelDto> GetCastsAndCrewsOfTv(long? tvApiId);
    }
}
