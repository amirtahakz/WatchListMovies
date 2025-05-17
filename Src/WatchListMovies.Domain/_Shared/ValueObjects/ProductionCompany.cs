using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects;


public class ProductionCompany : BaseValueObject
{
    public ProductionCompany()
    {

    }

    public ProductionCompany(Guid? mediaId , long? apiModelId, string? name, string? logoPath, string? originCountry)
    {
        ApiModelId = apiModelId;
        Name = name;
        LogoPath = logoPath;
        OriginCountry = originCountry;
        MediaId = mediaId;
    }
    public Guid? MediaId { get; set; }
    public long? ApiModelId { get; set; }
    public string? Name { get; set; }
    public string? LogoPath { get; set; }
    public string? OriginCountry { get; set; }
}
