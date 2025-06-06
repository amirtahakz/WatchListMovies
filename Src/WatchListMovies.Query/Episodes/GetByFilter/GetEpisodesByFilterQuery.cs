using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Episodes.DTOs;
using WatchListMovies.Query.Seasons.DTOs;
using WatchListMovies.Query.Seasons.GetByFilter;

namespace WatchListMovies.Query.Episodes.GetByFilter
{
    public class GetEpisodesByFilterQuery : QueryFilter<EpisodeFilterResult, EpisodeFilterParams>
    {
        public GetEpisodesByFilterQuery(EpisodeFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
