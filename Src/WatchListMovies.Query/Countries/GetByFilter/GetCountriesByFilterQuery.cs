using WatchListMovies.Common.Query;
using WatchListMovies.Query.Countries.DTOs;
using WatchListMovies.Query.Languages.DTOs;
using WatchListMovies.Query.Languages.GetByFilter;

namespace WatchListMovies.Query.Countries.GetByFilter
{
    public class GetCountriesByFilterQuery : QueryFilter<CountryFilterResult, CountryFilterParams>
    {
        public GetCountriesByFilterQuery(CountryFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
