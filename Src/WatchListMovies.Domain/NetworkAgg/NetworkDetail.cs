using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.NetworkAgg
{
    public class NetworkDetail : BaseEntity
    {
        public NetworkDetail()
        {
            
        }
        public NetworkDetail(
            string? headquarters,
            string? homepage,
            long? apiModelId,
            string? logoPath,
            string? name,
            string? originCountry,
            Guid? parrentId)
        {
            Headquarters = headquarters;
            Homepage = homepage;
            ApiModelId = apiModelId;
            LogoPath = logoPath;
            Name = name;
            OriginCountry = originCountry;
            ParrentId = parrentId;
        }

        public string? Headquarters { get; set; }
        public string? Homepage { get; set; }
        public long? ApiModelId { get; set; }
        public string? LogoPath { get; set; }
        public string? Name { get; set; }
        public string? OriginCountry { get; set; }
        public Guid? ParrentId { get; set; }
    }
}
