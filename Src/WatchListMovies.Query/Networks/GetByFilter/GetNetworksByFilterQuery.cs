using WatchListMovies.Common.Query;
using WatchListMovies.Query.Networks.DTOs;

namespace WatchListMovies.Query.Networks.GetByFilter
{
    public class GetNetworksByFilterQuery : QueryFilter<NetworkFilterResult, NetworkFilterParams>
    {
        public GetNetworksByFilterQuery(NetworkFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
