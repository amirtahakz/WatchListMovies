using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CompanyAgg
{
    public class CompanyDetail : BaseEntity
    {
        public CompanyDetail()
        {
            
        }

        public CompanyDetail(
            Guid? parrentId,
            string? description,
            string? headquarters,
            string? homepage,
            long? apiModelId,
            string? logoPath,
            string? name,
            string? originCountry,
            string? parentCompany)
        {
            ParrentId = parrentId;
            Description = description;
            Headquarters = headquarters;
            Homepage = homepage;
            ApiModelId = apiModelId;
            LogoPath = logoPath;
            Name = name;
            OriginCountry = originCountry;
            ParentCompany = parentCompany;
        }

        public Guid? ParrentId { get; set; }
        public string? Description { get; set; }
        public string? Headquarters { get; set; }
        public string? Homepage { get; set; }
        public long? ApiModelId { get; set; }
        public string? LogoPath { get; set; }
        public string? Name { get; set; }
        public string? OriginCountry { get; set; }
        public string? ParentCompany { get; set; }
    }
}
