using WatchListMovies.Common.Query;
using WatchListMovies.Query.Favorites.DTOs;

namespace WatchListMovies.Query.Favorites.GetByFilter
{
    public class GetFavoriteByFilterQuery : QueryFilter<FavoriteFilterResult, FavoriteFilterParams>
    {
        public GetFavoriteByFilterQuery(FavoriteFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
