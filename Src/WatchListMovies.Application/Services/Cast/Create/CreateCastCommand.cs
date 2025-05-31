
using WatchListMovies.Common.Application;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.ValueObjects;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.Services.Cast.Create
{
    public class CreateCastCommand : IBaseCommand<Guid>
    {
        public bool? Adult { get; set; }
        public long? Gender { get; set; }
        public long? ApiModelId { get; set; }
        public string? KnownForDepartment { get; set; }
        public string? Name { get; set; }
        public string? OriginalName { get; set; }
        public double? Popularity { get; set; }
        public string? ProfilePath { get; set; }
        public List<CastImage>? CastImages { get; set; }
        public CastExternalId? CastExternalId { get; set; }
        public CastDetail? CastDetails { get; set; }
        public List<CastKnownForValueObject>? CastKnownFors { get; set; }
    }
}
