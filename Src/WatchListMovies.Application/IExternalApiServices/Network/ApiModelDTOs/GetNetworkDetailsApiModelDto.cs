using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Network.ApiModelDTOs
{
    public class GetNetworkDetailsApiModelDto
    {
        [JsonProperty("headquarters")]
        public string? Headquarters { get; set; }

        [JsonProperty("homepage")]
        public string? Homepage { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("logo_path")]
        public string? LogoPath { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("origin_country")]
        public string? OriginCountry { get; set; }
    }
}
