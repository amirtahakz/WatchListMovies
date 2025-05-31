using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Movies.DTOs;
using WatchListMovies.Query.Movies.GetSimilar;

namespace WatchListMovies.Query.Movies.GetRecommended
{
    public class GetRecommendedMoviesQuery : IQuery<List<MovieDto>?>
    {
        public int Take { get; set; } = 20;
    }
}
