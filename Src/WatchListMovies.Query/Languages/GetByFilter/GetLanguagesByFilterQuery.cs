using WatchListMovies.Common.Query;
using WatchListMovies.Query.Languages.DTOs;

namespace WatchListMovies.Query.Languages.GetByFilter
{
    public class GetLanguagesByFilterQuery : QueryFilter<LanguageFilterResult, LanguageFilterParams>
    {
        public GetLanguagesByFilterQuery(LanguageFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
