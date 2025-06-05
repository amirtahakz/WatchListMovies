using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Genres.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Genres.GetByFilter
{
    public class GetGenresByFilterQuery : QueryFilter<GenreFilterResult, GenreFilterParams>
    {
        public GetGenresByFilterQuery(GenreFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
