using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Query.ContentCast.DTOs;
using WatchListMovies.Query.Movies.DTOs;

namespace WatchListMovies.Query.ContentCast
{
    public static class ContentCastMapper
    {
        public static ContentCastDto Map(this Domain.ContentCastAgg.ContentCast contentCast)
        {
            return new ContentCastDto()
            {
                Id = contentCast.Id,
                CreationDate = contentCast.CreationDate,
                CastApiModelId = contentCast.CastApiModelId,
                ContentApiModelId = contentCast.ContentApiModelId,
                ContentType = contentCast.ContentType,
                CreditType = contentCast.CreditType,
                Character = contentCast.Character,
                CreditId = contentCast.CreditId,
                Department = contentCast.Department,
                Job = contentCast.Job
            };
        }
    }
}
