using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg.ValueObjects
{
    public class CreatedByValueObject : BaseValueObject
    {
        public CreatedByValueObject()
        {

        }

        public CreatedByValueObject(
            Guid? mediaId,
            long? apiModelId,
            string? name,
            string? originalName,
            int? gender,
            string? profilePath)
        {
            ApiModelId = apiModelId;
            Name = name;
            OriginalName = originalName;
            Gender = gender;
            ProfilePath = profilePath;
            MediaId = mediaId;
        }
        public Guid? MediaId { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public int? Gender { get; set; }
        public string? ProfilePath { get; set; }
    }

}
