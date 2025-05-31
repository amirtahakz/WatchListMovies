using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg.ValueObjects
{
    public class NetworkValueObject : BaseValueObject
    {
        public NetworkValueObject()
        {
            
        }

        public NetworkValueObject(
            Guid? mediaId,
            long? apiModelId,
            string? name,
            string? logoPath,
            string? originCountry)
        {
            ApiModelId = apiModelId;
            Name = name;
            LogoPath = logoPath;
            OriginCountry = originCountry;
            MediaId = mediaId;
        }
        public Guid? MediaId { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? LogoPath { get; set; }
        public string? OriginCountry { get; set; }
    }

}
