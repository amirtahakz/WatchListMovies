using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Configuration.ApiModelDTOs
{
    public class LanguagesApiModelDto
    {
        [JsonProperty("iso_639_1")]
        public string? Iso6391 { get; set; }

        [JsonProperty("english_name")]
        public string? EnglishName { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }
}
