using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.CompanyAgg;
using WatchListMovies.Query.Collections.DTOs;
using WatchListMovies.Query.Companies.DTOs;

namespace WatchListMovies.Query.Collections
{
    public static class CollectionMapper
    {
        public static CollectionDto Map(this Domain.CollectionAgg.Collection collection)
        {
            return new CollectionDto()
            {
                ApiModelId = collection.ApiModelId,
                BackdropPath = collection.BackdropPath, 
                CreationDate = collection.CreationDate,
                Id = collection.Id,
                Name = collection.Name,
                PosterPath = collection.PosterPath,
                CollectionDetail = collection.CollectionDetail,
            };
        }

        public static List<CollectionDto> Map(this List<Domain.CollectionAgg.Collection> collections)
        {
            var result = new List<CollectionDto>();

            foreach (var item in collections)
                result.Add(item.Map());

            return result;
        }
    }
}
