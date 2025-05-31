using WatchListMovies.Common.Query;
using WatchListMovies.Domain.GenreAgg.Enums;

namespace WatchListMovies.Query.Genre.DTOs
{
    public class GenreDto : BaseDto
    {
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public GenreType? GenreType { get; set; }
    }

    public class GenreFilterParams : BaseFilterParam
    {
        public Guid? Id { get; set; }
        public DateTime? CreationDate { get; set; }
        public long? ApiModelId { get; set; }
        public string? Name { get; set; }
        public GenreType? GenreType { get; set; }

    }
    public class GenreFilterResult : BaseFilter<GenreDto, GenreFilterParams>
    {

    }
}
