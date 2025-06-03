using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects;


public class SpokenLanguageValueObject : BaseValueObject
{
    public SpokenLanguageValueObject()
    {

    }

    public SpokenLanguageValueObject(Guid? ParrentId, string? iso6391, string? name, string? englishName)
    {
        Iso6391 = iso6391;
        Name = name;
        EnglishName = englishName;
        ParrentId = ParrentId;
    }
    public Guid? ParrentId { get; set; }
    public string? Iso6391 { get; set; }
    public string? Name { get; set; }
    public string? EnglishName { get; set; }
}

