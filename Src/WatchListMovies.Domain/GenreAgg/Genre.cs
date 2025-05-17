using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.GenreAgg.Enums;

namespace WatchListMovies.Domain.GenreAgg
{
    public class Genre : BaseEntity
    {
        public Genre()
        {
            
        }

        public Genre(
            long? apiModelId,
            string? name,
            GenreType? genreType)
        {
            ApiModelId = apiModelId;
            Name = name;
            GenreType = genreType;
        }

        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public GenreType? GenreType { get; set; }
    }
}
