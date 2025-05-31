using WatchListMovies.Common.Application;

namespace WatchListMovies.Application.Services.Movie.MakeRecommended
{
    public class MakeRecommendedAMovieByImdbIdCommand : IBaseCommand<bool>
    {
        public string ImdbId { get; set; }
    }
}
