using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Collection.DTOs;
using WatchListMovies.Query.Companies.DTOs;
using WatchListMovies.Query.Companies.GerByFilter;

namespace WatchListMovies.Query.Collection.GetByFilter
{
    public class GetCollectionByFilterQuery : QueryFilter<CollectionFilterResult, CollectionFilterParams>
    {
        public GetCollectionByFilterQuery(CollectionFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
