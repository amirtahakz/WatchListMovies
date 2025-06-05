using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Collection.ApiModelDTOs
{
    public class GetCollectionDetailsApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("overview")]
        public string? Overview { get; set; }

        [JsonProperty("poster_path")]
        public string? PosterPath { get; set; }

        [JsonProperty("backdrop_path")]
        public string? BackdropPath { get; set; }
    }
}
