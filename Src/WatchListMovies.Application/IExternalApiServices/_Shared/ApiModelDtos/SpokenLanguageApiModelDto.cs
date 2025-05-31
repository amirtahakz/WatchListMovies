﻿using Newtonsoft.Json;

namespace WatchListMovies.Application.IExternalApiServices._Shared.ApiModelDtos
{
    public class SpokenLanguageApiModelDto
    {
        [JsonProperty("english_name")]
        public string? EnglishName { get; set; }

        [JsonProperty("iso_639_1")]
        public string? Iso6391 { get; set; }

        [JsonProperty("name")]
        public string? Name { get; set; }
    }

}
