using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CountryAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Query.Countries.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.Countries
{
    public static class CountryMapper
    {
        public static CountryDto Map(this Country country)
        {
            return new CountryDto()
            {
                NativeName = country.NativeName,
                EnglishName = country.EnglishName,
                CreationDate = country.CreationDate,
                Id = country.Id,
                Iso31661 = country.Iso31661
            };
        }

        public static List<CountryDto> Map(this List<Country> countries)
        {
            var result = new List<CountryDto>();
            foreach (var item in countries)
            {
                result.Add(item.Map());
            }
            return result;
        }
    }
}
