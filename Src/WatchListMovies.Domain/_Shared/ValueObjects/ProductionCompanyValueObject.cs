using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects;


public class ProductionCompanyValueObject : BaseValueObject
{
    public ProductionCompanyValueObject()
    {

    }

    public ProductionCompanyValueObject(Guid? ParrentId , long? apiModelId, string? name, string? logoPath, string? originCountry)
    {
        ApiModelId = apiModelId;
        Name = name;
        LogoPath = logoPath;
        OriginCountry = originCountry;
        ParrentId = ParrentId;
    }
    public Guid? ParrentId { get; set; }
    public long? ApiModelId { get; set; }
    public string? Name { get; set; }
    public string? LogoPath { get; set; }
    public string? OriginCountry { get; set; }
}
