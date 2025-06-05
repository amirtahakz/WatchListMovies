using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.ContentCastAgg.Enums;
using WatchListMovies.Domain.ContentImageAgg.Enums;

namespace WatchListMovies.Domain.ContentImageAgg
{
    public class ContentImage : BaseEntity
    {
        public ContentImage()
        {

        }
        public ContentImage(
            long? contentApiModelId,
            double? aspectRatio,
            long? height,
            string? iso6391,
            string? filePath,
            double? voteAverage,
            long? voteCount,
            long? width,
            ContentImageTypeEnum? contentImageType)
        {
            ContentApiModelId = contentApiModelId;
            AspectRatio = aspectRatio;
            Height = height;
            Iso6391 = iso6391;
            FilePath = filePath;
            VoteAverage = voteAverage;
            VoteCount = voteCount;
            Width = width;
            ContentImageType = contentImageType;
        }

        public long? ContentApiModelId { get; set; }
        public double? AspectRatio { get; set; }
        public long? Height { get; set; }
        public string? Iso6391 { get; set; }
        public string? FilePath { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public long? Width { get; set; }
        public ContentImageTypeEnum? ContentImageType { get; set; }
    }
}
