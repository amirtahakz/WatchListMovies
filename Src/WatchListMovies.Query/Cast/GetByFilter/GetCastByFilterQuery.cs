using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Cast.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Cast.GetByFilter
{
    public class GetCastByFilterQuery : QueryFilter<CastFilterResult, CastFilterParams>
    {
        public GetCastByFilterQuery(CastFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
