using WatchListMovies.Common.Application;

namespace WatchListMovies.Application.Services.Tv.MakeRecommended
{
    public class MakeRecommendedATvByApiModelIdCommand : IBaseCommand<bool>
    {
        public long ApiModelId { get; set; }
    }
}
