using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ContentCastAgg
{
    public class ContentCastConfiguration : IEntityTypeConfiguration<ContentCast>
    {
        public void Configure(EntityTypeBuilder<ContentCast> builder)
        {
            builder.HasIndex(b => b.ContentApiModelId);
            builder.HasIndex(b => b.CreditType);
            builder.HasIndex(b => b.ContentType);
            builder.HasIndex(b => b.CastApiModelId);
            
        }
    }
}
