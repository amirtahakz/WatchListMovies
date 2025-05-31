using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.Configurations
{
    public class JobSchedulesConfig
    {
        public string SyncPopularMovies { get; set; }
        public string SyncMovieKeyYoutubeTrailers { get; set; }
        public string SyncCastsAndCrewsOfMovie { get; set; }
        public string SyncPopularTvs { get; set; }
        public string SyncPopularCasts { get; set; }
        public string SyncMovieDetails { get; set; }
        public string SyncTvDetails { get; set; }
        public string SyncCastsAndCrewsOfTv { get; set; }
        public string SyncCastDetails { get; set; }
        public string SyncCastExternalIds { get; set; }
        public string SyncGenres { get; set; }
        public string SyncCastImages { get; set; }
    }
}
