using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CollectionAgg
{
    public class CollectionDetail : BaseEntity
    {
        public CollectionDetail()
        {
            
        }
        public CollectionDetail(
            Guid parrentId,
            long? apiModelId,
            string? name,
            string? overview,
            string? posterPath,
            string? backdropPath)
        {
            ParrentId = parrentId;
            ApiModelId = apiModelId;
            Name = name;
            Overview = overview;
            PosterPath = posterPath;
            BackdropPath = backdropPath;
        }

        public Guid ParrentId { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? Overview { get; set; }
        public string? PosterPath { get; set; }
        public string? BackdropPath { get; set; }
    }
}
