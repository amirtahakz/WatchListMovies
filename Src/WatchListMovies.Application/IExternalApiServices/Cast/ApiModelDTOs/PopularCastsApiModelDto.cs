using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs
{
    public class PopularCastsApiModelDto
    {
        [JsonProperty("page")]
        public long? Page { get; set; }

        [JsonProperty("results")]
        public List<PopularCastDetailsItemApiModelDto> Casts { get; set; }

        [JsonProperty("total_pages")]
        public long? TotalPages { get; set; }

        [JsonProperty("total_results")]
        public long? TotalResults { get; set; }
    }

    public class KnownForApiModelDto
    {

        [JsonProperty("id")]
        public long? Id { get; set; }

    }

    public class PopularCastDetailsItemApiModelDto
    {
        [JsonProperty("adult")]
        public bool? Adult { get; set; }

        [JsonProperty("gender")]
        public long? Gender { get; set; }

        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("known_for_department")]
        public string? KnownForDepartment { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }

        [JsonProperty("original_name")]
        public string? OriginalName { get; set; }

        [JsonProperty("popularity")]
        public double? Popularity { get; set; }

        [JsonProperty("profile_path")]
        public string? ProfilePath { get; set; }

        [JsonProperty("known_for")]
        public List<KnownForApiModelDto>? KnownFor { get; set; }
    }
}
