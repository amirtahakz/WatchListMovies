using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Season.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Season
{
    public interface ISeasonApiService
    {
        Task<GetSeasonDetailsApiModelDto> GetSeasonDetails(long? tvApiId, long? seasonNumber);
    }
}
