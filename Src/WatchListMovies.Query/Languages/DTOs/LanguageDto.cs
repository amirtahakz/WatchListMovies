using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Countries.DTOs;

namespace WatchListMovies.Query.Languages.DTOs
{
    public class LanguageDto : BaseDto
    {
        public string? Iso6391 { get; set; }
        public string? EnglishName { get; set; }
        public string? Name { get; set; }
    }

    public class LanguageFilterParams : BaseFilterParam
    {
        public List<string>? Iso6391 { get; set; }
        public List<string>? EnglishName { get; set; }
        public List<string>? Name { get; set; }
    }
    public class LanguageFilterResult : BaseFilter<LanguageDto, LanguageFilterParams>
    {

    }
}
