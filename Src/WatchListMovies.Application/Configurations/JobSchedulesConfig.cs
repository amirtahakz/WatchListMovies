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
        public string SyncPopularTvs { get; set; }
        public string SyncPopularCasts { get; set; }
        public string SyncMovieDetailsAndCompanies { get; set; }
        public string SyncTvDetailsAndCompanies { get; set; }
        public string SyncCastDetails { get; set; }
        public string SyncCastExternalIds { get; set; }
        public string SyncGenres { get; set; }
        public string SyncContentImages { get; set; }
        public string SyncContentCasts { get; set; }
        public string SyncCountries { get; set; }
        public string SyncLanguages { get; set; }
    }
}
