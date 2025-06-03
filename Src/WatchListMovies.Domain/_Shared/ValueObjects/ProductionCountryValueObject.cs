using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects;


public class ProductionCountryValueObject : BaseValueObject
{
    public ProductionCountryValueObject()
    {

    }

    public ProductionCountryValueObject(Guid? ParrentId, string? iso31661, string? name)
    {
        Iso31661 = iso31661;
        Name = name;
        ParrentId = ParrentId;
    }
    public Guid? ParrentId { get; set; }
    public string? Iso31661 { get; set; }
    public string? Name { get; set; }
}
