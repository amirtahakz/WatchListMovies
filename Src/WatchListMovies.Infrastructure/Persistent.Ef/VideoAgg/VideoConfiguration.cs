using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Infrastructure.Persistent.Ef.VideoAgg
{
    public class VideoConfiguration : IEntityTypeConfiguration<Domain.VideoAgg.Video>
    {
        public void Configure(EntityTypeBuilder<Domain.VideoAgg.Video> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Name);
        }
    }
}
