using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CastAgg
{
    public class Cast : BaseEntity
    {
        public Cast()
        {
            
        }

        public Cast(bool? adult,
            long? gender,
            long? apiModelId,
            string? knownForDepartment,
            string? name,
            string? originalName,
            double? popularity,
            string? profilePath,
            bool? isRecommendedByAdmin,
            CastExternalId? castExternalId,
            CastDetail? castDetails,
            IReadOnlyCollection<string>? castKnownForIds)
        {
            Adult = adult;
            Gender = gender;
            ApiModelId = apiModelId;
            KnownForDepartment = knownForDepartment;
            Name = name;
            OriginalName = originalName;
            Popularity = popularity;
            ProfilePath = profilePath;
            IsRecommendedByAdmin = isRecommendedByAdmin;
            CastExternalId = castExternalId;
            CastDetails = castDetails;
            MovieKnownForIds = castKnownForIds;
        }

        public void MakeRecommended()
        {
            IsRecommendedByAdmin = true;
        }

        public bool? Adult { get; set; }
        public long? Gender { get; set; }
        public long? ApiModelId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public bool? IsRecommendedByAdmin { get; set; }
        public CastExternalId? CastExternalId { get; set; }
        public CastDetail? CastDetails { get; set; }
        public IReadOnlyCollection<string>? MovieKnownForIds { get; set; }
    }
}
