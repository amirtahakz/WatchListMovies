using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WatchListMovies.Common.Application;
using WatchListMovies.Domain.GenreAgg.Enums;

namespace WatchListMovies.Application.Services.Genre.Create
{
    public class CreateGenreCommand : IBaseCommand<Guid>
    {
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public GenreType? GenreType { get; set; }
    }
}
