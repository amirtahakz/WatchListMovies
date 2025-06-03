using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs
{
    public class GetCreditsOfCastApiModelDto
    {
        [JsonProperty("cast")]
        public List<CreditsOfCastItemApiModelDto>? Casts { get; set; }

        [JsonProperty("crew")]
        public List<CreditsOfCastItemApiModelDto>? Crews { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }
    }

    public class CreditsOfCastItemApiModelDto
    {

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("character")]
        public string? Character { get; set; }

        [JsonProperty("department")]
        public string? Department { get; set; }

        [JsonProperty("job")]
        public string? Job { get; set; }

        [JsonProperty("credit_id")]
        public string? CreditId { get; set; }

    }

    
}
