using WatchListMovies.Common.Query;
using WatchListMovies.Query.Favorites.DTOs;

namespace WatchListMovies.Query.Favorites.GetByFilter
{
    public class GetFavoritesByFilterQuery : QueryFilter<FavoriteFilterResult, FavoriteFilterParams>
    {
        public GetFavoritesByFilterQuery(FavoriteFilterParams filterParams) : base(filterParams)
        {
        }
    }
}
