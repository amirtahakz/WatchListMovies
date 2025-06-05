using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Companies.DTOs;
using WatchListMovies.Query.Countries.DTOs;

namespace WatchListMovies.Query.Companies.GerByFilter
{
    public class GetCompaniesByFilterQuery : QueryFilter<CompanyFilterResult, CompanyFilterParams>
    {
        public GetCompaniesByFilterQuery(CompanyFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
