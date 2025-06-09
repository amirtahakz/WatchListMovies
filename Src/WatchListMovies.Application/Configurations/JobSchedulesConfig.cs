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
        public string SyncPopularTvs { get; set; }
        public string SyncPopularCasts { get; set; }
        public string SyncMovieDetails { get; set; }
        public string SyncTvDetails { get; set; }
        public string SyncCastDetails { get; set; }
        public string SyncCastExternalIds { get; set; }
        public string SyncGenres { get; set; }
        public string SyncCastImages { get; set; }
        public string SyncTvImages { get; set; }
        public string SyncMovieImages { get; set; }
        public string SyncContentCasts { get; set; }
        public string SyncCountries { get; set; }
        public string SyncLanguages { get; set; }
        public string SyncCompanyDetails { get; set; }
        public string SyncMovieCompanies { get; set; }
        public string SyncTvCompanies { get; set; }
        public string SyncCollections { get; set; }
        public string SyncCollectionDetails { get; set; }
        public string SyncNetworks { get; set; }
        public string SyncNetworkDetails { get; set; }
        public string SyncSeasons { get; set; }
        public string SyncEpisodes { get; set; }
        public string SyncMovieVideos { get; set; }
        public string SyncTvVideos { get; set; }

    }
}
