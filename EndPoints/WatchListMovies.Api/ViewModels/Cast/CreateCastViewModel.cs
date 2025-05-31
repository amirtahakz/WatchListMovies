using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.CastAgg.ValueObjects;

namespace WatchListMovies.Api.ViewModels.Cast
{
    public class CreateCastViewModel
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
