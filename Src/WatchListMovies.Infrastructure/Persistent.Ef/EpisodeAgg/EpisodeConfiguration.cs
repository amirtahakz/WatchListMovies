using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatchListMovies.Infrastructure.Persistent.Ef.EpisodeAgg
{
    public class EpisodeConfiguration : IEntityTypeConfiguration<Domain.EpisodeAgg.Episode>
    {
        public void Configure(EntityTypeBuilder<Domain.EpisodeAgg.Episode> builder)
        {
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Name);
        }
    }
}
