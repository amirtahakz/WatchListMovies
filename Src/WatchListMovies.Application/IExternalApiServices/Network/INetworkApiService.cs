using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Network.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Network
{
    public interface INetworkApiService
    {
        Task<GetNetworkDetailsApiModelDto> GetNetworkDetails(long networkApiId);
    }
}
