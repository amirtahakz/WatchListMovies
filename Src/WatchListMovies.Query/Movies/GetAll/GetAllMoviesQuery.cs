using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Tvs.DTOs;

namespace WatchListMovies.Query.Movies.GetAll
{
    public class GetAllMoviesQuery : IQuery<List<MovieDto>?>
    {
    }
}
