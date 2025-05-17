using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Genre.ApiModelDTOs
{
    public class GetGenresApiModelDto
    {
        [JsonProperty("genres")]
        public List<GetGenresApiItem> Genres { get; set; }
    }
    public class GetGenresApiItem
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }
    }
}
