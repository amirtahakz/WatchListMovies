using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.ListAgg.Enums;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Countries.DTOs
{
    public class CountryDto : BaseDto
    {
        public string? Iso31661 { get; set; }
        public string? EnglishName { get; set; }
        public string? NativeName { get; set; }
    }

    public class CountryFilterParams : BaseFilterParam
    {
        public List<string>? Iso31661 { get; set; }
        public List<string>? EnglishName { get; set; }
        public List<string>? NativeName { get; set; }
    }
    public class CountryFilterResult : BaseFilter<CountryDto, CountryFilterParams>
    {

    }
}
