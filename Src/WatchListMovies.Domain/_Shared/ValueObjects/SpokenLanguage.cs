using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain._Shared.ValueObjects;


public class SpokenLanguage : BaseValueObject
{
    public SpokenLanguage()
    {

    }

    public SpokenLanguage(Guid? mediaId, string? iso6391, string? name, string? englishName)
    {
        Iso6391 = iso6391;
        Name = name;
        EnglishName = englishName;
        MediaId = mediaId;
    }
    public Guid? MediaId { get; set; }
    public string? Iso6391 { get; set; }
    public string? Name { get; set; }
    public string? EnglishName { get; set; }
}

