using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs
{
    public class CastExternalIdsApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("freebase_mid")]
        public string FreebaseMid { get; set; }

        [JsonProperty("freebase_id")]
        public string FreebaseId { get; set; }

        [JsonProperty("imdb_id")]
        public string ImdbId { get; set; }

        [JsonProperty("tvrage_id")]
        public long? TvrageId { get; set; }

        [JsonProperty("wikidata_id")]
        public string WikidataId { get; set; }

        [JsonProperty("facebook_id")]
        public string FacebookId { get; set; }

        [JsonProperty("instagram_id")]
        public string InstagramId { get; set; }

        [JsonProperty("tiktok_id")]
        public string TiktokId { get; set; }

        [JsonProperty("twitter_id")]
        public string TwitterId { get; set; }

        [JsonProperty("youtube_id")]
        public string YoutubeId { get; set; }
    }
}
