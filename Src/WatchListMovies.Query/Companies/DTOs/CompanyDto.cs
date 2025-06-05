using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Query.Countries.DTOs;

namespace WatchListMovies.Query.Companies.DTOs
{
    public class CompanyDto : BaseDto
    {
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? LogoPath { get; set; }
        public string? OriginCountry { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
    }

    public class CompanyFilterParams : BaseFilterParam
    {
        public List<long>? ApiModelIds { get; set; }
        public string? Name { get; set; }
        public string? OriginCountry { get; set; }
    }
    public class CompanyFilterResult : BaseFilter<CompanyDto, CompanyFilterParams>
    {

    }
}
