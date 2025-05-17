using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Query;
using WatchListMovies.Query.Favorites.DTOs;
using WatchListMovies.Query.Lists.DTOs;
using WatchListMovies.Query.Lists.GetById;

namespace WatchListMovies.Query.Favorites.GetById
{
    public class GetFavoriteByIdQuery : IQuery<FavoriteDto?>
    {
        public GetFavoriteByIdQuery(Guid favoriteId)
        {
            FavoriteId = favoriteId;
        }

        public Guid FavoriteId { get; private set; }
    }
}
