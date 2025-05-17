using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.CastAgg.ValueObjects;

namespace WatchListMovies.Domain.CastAgg
{
    public class Cast : BaseEntity
    {
        public Cast()
        {
            
        }

        public Cast(
            bool? adult,
            long? gender,
            long? apiModelId,
            string? knownForDepartment,
            string? name,
            string? originalName,
            double? popularity,
            string? profilePath,
            List<CastImage> castImages,
            CastExternalId? castExternalId,
            CastDetail? castDetails,
            List<CastKnownFor>? castKnownFors)
        {
            Adult = adult;
            Gender = gender;
            ApiModelId = apiModelId;
            KnownForDepartment = knownForDepartment;
            Name = name;
            OriginalName = originalName;
            Popularity = popularity;
            ProfilePath = profilePath;
            CastImages = castImages;
            CastExternalId = castExternalId;
            CastDetails = castDetails;
            CastKnownFors = castKnownFors;
        }

        public bool? Adult { get; set; }
        public long? Gender { get; set; }
        public long? ApiModelId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public List<CastImage>? CastImages { get; set; }
        public CastExternalId? CastExternalId { get; set; }
        public CastDetail? CastDetails { get; set; }
        public List<CastKnownFor>? CastKnownFors { get; set; }
    }
}
