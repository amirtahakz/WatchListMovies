using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Tvs.GetByFilter
{
    public class GetTvsByFilterQuery : QueryFilter<TvFilterResult, TvFilterParams>
    {
        public GetTvsByFilterQuery(TvFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
