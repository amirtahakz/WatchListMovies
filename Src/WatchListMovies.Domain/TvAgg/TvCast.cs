using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.TvAgg
{
    public class TvCast : BaseEntity
    {
        public TvCast()
        {

        }

        public TvCast(Guid? movieDetailsId,
            bool? adult,
            int? gender,
            long? apiModelId,
            string? knownForDepartment,
            string? name,
            string? originalName,
            double? popularity,
            string? profilePath,
            long? castId,
            string? character,
            string? creditId,
            int? order)
        {
            MovieDetailsId = movieDetailsId;
            Adult = adult;
            Gender = gender;
            ApiModelId = apiModelId;
            KnownForDepartment = knownForDepartment;
            Name = name;
            OriginalName = originalName;
            Popularity = popularity;
            ProfilePath = profilePath;
            CastId = castId;
            Character = character;
            CreditId = creditId;
            Order = order;
        }

        public Guid? MovieDetailsId { get; set; }
        public bool? Adult { get; set; }
        public int? Gender { get; set; }
        public long? ApiModelId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public long? CastId { get; set; }
        public string? Character { get; set; }
        public string? CreditId { get; set; }
        public int? Order { get; set; }
    }
}
