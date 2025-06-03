using WatchListMovies.Common.Application;

namespace WatchListMovies.Application.Services.Cast.MakeRecommended
{
    public class MakeRecommendedACastByApiModelIdCommand : IBaseCommand<bool>
    {
        public long ApiModelId { get; set; }
    }
}
