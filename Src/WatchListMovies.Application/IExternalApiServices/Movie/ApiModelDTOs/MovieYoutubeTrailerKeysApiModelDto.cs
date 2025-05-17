using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs
{
    public class MovieYoutubeTrailerKeysApiModelDto
    {
        [JsonProperty("id")]
        public long Id { get; set; }

        [JsonProperty("results")]
        public List<MovieYoutubeTrailerKeysItem> Results { get; set; }
    }

    public class MovieYoutubeTrailerKeysItem
    {
        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("iso_3166_1")]
        public string Iso31661 { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("key")]
        public string Key { get; set; }

        [JsonProperty("site")]
        public string Site { get; set; }

        [JsonProperty("size")]
        public long Size { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("official")]
        public bool Official { get; set; }

        [JsonProperty("published_at")]
        public DateTime PublishedAt { get; set; }

        [JsonProperty("id")]
        public string Id { get; set; }
    }
}
