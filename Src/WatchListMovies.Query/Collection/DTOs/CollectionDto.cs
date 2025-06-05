using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Domain.CollectionAgg;
using WatchListMovies.Query.Companies.DTOs;

namespace WatchListMovies.Query.Collection.DTOs
{
    public class CollectionDto : BaseDto
    {
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? PosterPath { get; set; }
        public string? BackdropPath { get; set; }
        public CollectionDetail? CollectionDetail { get; set; }
    }

    public class CollectionFilterParams : BaseFilterParam
    {
        public List<long>? ApiModelIds { get; set; }
        public string? Name { get; set; }
    }
    public class CollectionFilterResult : BaseFilter<CollectionDto, CollectionFilterParams>
    {

    }
}
