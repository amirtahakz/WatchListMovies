using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.MovieAgg.ValueObjects
{
    public class BelongsToCollectionValueObject : BaseValueObject
    {
        public BelongsToCollectionValueObject()
        {
            
        }

        public BelongsToCollectionValueObject(
            Guid movieDetailId,
            long? apiModelId,
            string? name,
            string? posterPath,
            string? backdropPath)
        {
            ParrentId = movieDetailId;
            ApiModelId = apiModelId;
            Name = name;
            PosterPath = posterPath;
            BackdropPath = backdropPath;
        }
        public Guid? ParrentId { get; set; }

        public long? ApiModelId { get; set; }

        public string? Name { get; set; }

        public string? PosterPath { get; set; }

        public string? BackdropPath { get; set; }
    }
}
