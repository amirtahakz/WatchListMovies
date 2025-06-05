using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Collection.ApiModelDTOs;

namespace WatchListMovies.Application.IExternalApiServices.Collection
{
    public interface ICollectionApiService
    {
        Task<GetCollectionDetailsApiModelDto> GetCollectionDetails(long collectionApiId);
    }
}
