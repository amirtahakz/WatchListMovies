using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CompanyAgg
{
    public class Company : BaseEntity
    {
        public Company(
            long? apiModelId,
            string? name,
            string? logoPath,
            string? originCountry,
            CompanyDetail? companyDetail)
        {
            ApiModelId = apiModelId;
            Name = name;
            LogoPath = logoPath;
            OriginCountry = originCountry;
            CompanyDetail = companyDetail;
        }

        public Company()
        {

        }

        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public string? LogoPath { get; set; }
        public string? OriginCountry { get; set; }
        public CompanyDetail? CompanyDetail { get; set; }
    }
}
