using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Seasons.DTOs;
using WatchListMovies.Query.Seasons.GetByFilter;
using WatchListMovies.Query.Videos.DTOs;

namespace WatchListMovies.Query.Videos.GetByFilter
{
    public class GetVideosByFilterQuery : QueryFilter<VideoFilterResult, VideoFilterParams>
    {
        public GetVideosByFilterQuery(VideoFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
