using WatchListMovies.Common.Application;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Application.Services.Tv.Create
{
    public class CreateTvCommand : IBaseCommand<Guid>
    {
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalName { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? FirstAirDate { get; set; }
        public string? Name { get; set; }
        public double? VoteAverage { get; set; }
        public long? VoteCount { get; set; }
        public TvDetail TvDetail { get; set; }
    }
}
