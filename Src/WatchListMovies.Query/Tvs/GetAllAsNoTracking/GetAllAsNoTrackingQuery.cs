using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Tvs.DTOs;
using WatchListMovies.Query.Users;
using WatchListMovies.Query.Users.DTOs;
using WatchListMovies.Query.Users.GetByPhoneNumber;

namespace WatchListMovies.Query.Tvs.GetAllAsNoTracking
{
    public class GetAllAsNoTrackingQuery : IQuery<List<TvDto>?>
    {
    }
}
