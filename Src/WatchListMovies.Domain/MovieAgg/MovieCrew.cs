using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.MovieAgg
{
    public class MovieCrew : BaseEntity
    {
        public MovieCrew()
        {
            
        }

        public MovieCrew(Guid? movieDetailsId,
            bool? adult,
            int? gender,
            long? apiModelId,
            string? knownForDepartment,
            string? name,
            string? originalName,
            double? popularity,
            string? profilePath,
            string? creditId,
            string? department,
            string? job)
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
            CreditId = creditId;
            Department = department;
            Job = job;
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
        public string? CreditId { get; set; }
        public string? Department { get; set; }
        public string? Job { get; set; }
    }
}
