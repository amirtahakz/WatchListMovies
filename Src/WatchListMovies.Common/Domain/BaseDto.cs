using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Common.Domain
{
    public class BaseDto
    {
        public Guid Id { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
