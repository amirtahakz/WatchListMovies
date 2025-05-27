using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.FavoriteAgg;
using WatchListMovies.Domain.ListAgg;
using WatchListMovies.Query.Favorites.DTOs;
using WatchListMovies.Query.Lists.DTOs;

namespace WatchListMovies.Query.Favorites
{
    public static class FavoriteMapper
    {
        public static FavoriteDto Map(this Favorite favorite)
        {
            return new FavoriteDto()
            {
                Id = favorite.Id,
                CreationDate = favorite.CreationDate,
                Note = favorite.Note,
                SubjectId = favorite.SubjectId,
                ListId = favorite.ListId,
                FavoriteType = favorite.FavoriteType,
                UserId = favorite.UserId,
            };
        }
    }
}
