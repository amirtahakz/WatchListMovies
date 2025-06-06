using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.NetworkAgg;
using WatchListMovies.Query.Collections.DTOs;

namespace WatchListMovies.Query.Networks.DTOs
{
    public class NetworkDto : BaseDto
    {
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? LogoPath { get; set; }
        public string? OriginCountry { get; set; }
        public NetworkDetail? NetworkDetail { get; set; }
    }

    public class NetworkFilterParams : BaseFilterParam
    {
        public List<long>? ApiModelIds { get; set; }
        public string? Name { get; set; }
        public string? OriginCountry { get; set; }
    }
    public class NetworkFilterResult : BaseFilter<NetworkDto, NetworkFilterParams>
    {

    }
}
