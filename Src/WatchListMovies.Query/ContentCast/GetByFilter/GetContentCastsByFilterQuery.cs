using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.ContentCast.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.ContentCast.GetByFilter
{
    public class GetContentCastsByFilterQuery : QueryFilter<ContentCastFilterResult, ContentCastFilterParams>
    {
        public GetContentCastsByFilterQuery(ContentCastFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
