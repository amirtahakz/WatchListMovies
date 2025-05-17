using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.CastAgg.ValueObjects;

namespace WatchListMovies.Domain.CastAgg
{
    public class CastDetail : BaseEntity
    {
        public CastDetail()
        {
            
        }

        public CastDetail(
            Guid? castId,
            bool? adult,
            string? biography,
            string? birthday,
            string? deathday,
            int? gender,
            string? homepage,
            long? apiModelId,
            string? imdbId,
            string? knownForDepartment,
            string? name,
            string? placeOfBirth,
            double? popularity,
            string? profilePath,
            IEnumerable<string>? castAlsoKnownAss)
        {
            CastId = castId;
            Adult = adult;
            Biography = biography;
            Birthday = birthday;
            Deathday = deathday;
            Gender = gender;
            Homepage = homepage;
            ApiModelId = apiModelId;
            ImdbId = imdbId;
            KnownForDepartment = knownForDepartment;
            Name = name;
            PlaceOfBirth = placeOfBirth;
            Popularity = popularity;
            ProfilePath = profilePath;
            CastAlsoKnownAss = castAlsoKnownAss.ToList();
        }

        public Guid? CastId { get; set; }
        public bool? Adult { get; set; }
        public string? Biography { get; set; }
        public string? Birthday { get; set; }
        public string? Deathday { get; set; }
        public int? Gender { get; set; }
        public string? Homepage { get; set; }
        public long? ApiModelId { get; set; }
        public string? ImdbId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? PlaceOfBirth { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }

        public IReadOnlyCollection<string>? CastAlsoKnownAss { get; set; }
    }
}
