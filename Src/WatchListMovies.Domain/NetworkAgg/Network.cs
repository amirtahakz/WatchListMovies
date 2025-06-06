using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.NetworkAgg
{
    public class Network : BaseEntity
    {
        public Network()
        {
            
        }
        public Network(
            long? apiModelId,
            string? name,
            string? logoPath,
            string? originCountry,
            NetworkDetail? networkDetail)
        {
            ApiModelId = apiModelId;
            Name = name;
            LogoPath = logoPath;
            OriginCountry = originCountry;
            NetworkDetail = networkDetail;
        }

        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? LogoPath { get; set; }
        public string? OriginCountry { get; set; }
        public NetworkDetail? NetworkDetail { get; set; }
    }
}
