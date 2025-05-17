using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Genre.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Genre.GetByFilter
{
    public class GetGenreByFilterQuery : QueryFilter<GenreFilterResult, GenreFilterParams>
    {
        public GetGenreByFilterQuery(GenreFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
