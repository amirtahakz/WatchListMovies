using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CollectionAgg
{
    public class Collection : BaseEntity
    {
        public Collection()
        {
            
        }

        public Collection(
            long? apiModelId,
            string? name,
            string? posterPath,
            string? backdropPath,
            CollectionDetail? collectionDetail)
        {
            ApiModelId = apiModelId;
            Name = name;
            PosterPath = posterPath;
            BackdropPath = backdropPath;
            CollectionDetail = collectionDetail;
        }

        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? PosterPath { get; set; }
        public string? BackdropPath { get; set; }
        public CollectionDetail? CollectionDetail { get; set; }
    }
}
