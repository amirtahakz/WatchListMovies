using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CastAgg
{
    public class CastImage : BaseEntity
    {
        public CastImage()
        {
            
        }
        public CastImage(
            Guid castId,
            double? aspectRatio,
            long? height,
            string? iso6391,
            string? filePath,
            double? voteAverage,
            long? voteCount,
            long? width)
        {
            CastId = castId;
            AspectRatio = aspectRatio;
            Height = height;
            Iso6391 = iso6391;
            FilePath = filePath;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            Width = width;
        }

        public Guid CastId { get; set; }
        public double? AspectRatio { get; set; }
        public long? Height { get; set; }
        public string? Iso6391 { get; set; }
        public string? FilePath { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public long? Width { get; set; }
    }
}
