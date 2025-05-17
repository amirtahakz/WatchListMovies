using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Common.Domain;
using WatchListMovies.Domain.FavoriteAgg.Enums;
using WatchListMovies.Domain.ListAgg.Enums;

namespace WatchListMovies.Domain.ListAgg
{
    public class List : BaseEntity
    {
        public List(
            Guid userId,
            string name,
            string description,
            ListType listType,
            bool isPrivate = true)
        {
            UserId = userId;
            Name = name;
            Description = description;
            ListType = listType;
            IsPrivate = isPrivate;
        }
        public List()
        {

        }

        public Guid UserId { get; set; }
        public string Name { get; set; }
        public bool IsPrivate { get; set; }
        public string Description { get; set; }
        public ListType ListType { get; set; }
    }
}
