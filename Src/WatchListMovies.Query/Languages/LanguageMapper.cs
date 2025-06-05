using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.LanguageAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Query.Languages.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Languages
{
    public static class LanguageMapper
    {
        public static LanguageDto Map(this Language language)
        {
            return new LanguageDto()
            {
                Id = language.Id,
                CreationDate = language.CreationDate,
                EnglishName = language.EnglishName,
                Name = language.Name,
                Iso6391 = language.Iso6391
            };
        }

        public static List<LanguageDto> Map(this List<Language> languages)
        {
            var result = new List<LanguageDto>();
            foreach (var language in languages)
            {
                result.Add(language.Map());
            }
            return result;
        }
    }
}
