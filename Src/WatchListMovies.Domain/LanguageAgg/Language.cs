using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Domain.LanguageAgg
{
    public class Language : BaseEntity
    {
        public Language()
        {
            
        }

        public Language(string? iso6391, string? englishName, string? name)
        {
            Iso6391 = iso6391;
            EnglishName = englishName;
            Name = name;
        }

        public string? Iso6391 { get; set; }
        public string? EnglishName { get; set; }
        public string? Name { get; set; }
    }
}
