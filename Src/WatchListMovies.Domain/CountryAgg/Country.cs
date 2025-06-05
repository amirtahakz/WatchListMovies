using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.CountryAgg
{
    public class Country : BaseEntity
    {
        public Country()
        {
            
        }

        public Country(string? iso31661, string? englishName, string? nativeName)
        {
            Iso31661 = iso31661;
            EnglishName = englishName;
            NativeName = nativeName;
        }

        public string? Iso31661 { get; set; }
        public string? EnglishName { get; set; }
        public string? NativeName { get; set; }
    }
}
