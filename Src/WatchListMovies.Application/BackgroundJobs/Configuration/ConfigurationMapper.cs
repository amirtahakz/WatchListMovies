using WatchListMovies.Application.IExternalApiServices.Configuration.ApiModelDTOs;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Domain.LanguageAgg;

namespace WatchListMovies.Application.BackgroundJobs.Configuration
{
    public static class ConfigurationMapper
    {

        public static List<Country> Map(this List<CountriesApiModelDto> model)
        {
            var result = new List<Country>();

            if (model.Any())
            {
                foreach (var item in model)
                    result.Add(item.Map());
            }

            return result;
        }

        public static Country Map(this CountriesApiModelDto model)
        {
            var result = new Country()
            {
                EnglishName = model.EnglishName,
                Iso31661 = model.Iso31661,
                NativeName = model.NativeName,
            };

            return result;
        }

        public static List<Language> Map(this List<LanguagesApiModelDto> model)
        {
            var result = new List<Language>();

            if (model.Any())
            {
                foreach (var item in model)
                    result.Add(item.Map());
            }

            return result;
        }

        public static Language Map(this LanguagesApiModelDto model)
        {
            var result = new Language()
            {
                EnglishName = model.EnglishName,
                Iso6391 = model.Iso6391,
                Name = model.Name,
            };

            return result;
        }
    }
}
