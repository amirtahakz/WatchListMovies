using AutoMapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CastAgg;

namespace WatchListMovies.Application.IExternalApiServices.Cast.ApiModelDTOs
{
    public class CastImagesApiModelDto
    {
        [JsonProperty("id")]
        public long? Id { get; set; }

        [JsonProperty("profiles")]
        public List<CastImagesItem>? Profiles { get; set; }
    }
    public class CastImagesItem
    {
        [JsonProperty("aspect_ratio")]
        public double? AspectRatio { get; set; }

        [JsonProperty("height")]
        public long? Height { get; set; }

        [JsonProperty("iso_639_1")]
        public string Iso6391 { get; set; }

        [JsonProperty("file_path")]
        public string FilePath { get; set; }

        [JsonProperty("vote_average")]
        public double? VoteAverage { get; set; }

        [JsonProperty("vote_count")]
        public long? VoteCount { get; set; }

        [JsonProperty("width")]
        public long? Width { get; set; }
    }

}
