using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchListMovies.Domain.ContentImageAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.ContentImageAgg
{
    public class ContentImageConfiguration : IEntityTypeConfiguration<ContentImage>
    {
        public void Configure(EntityTypeBuilder<ContentImage> builder)
        {
            builder.HasIndex(b => b.ContentApiModelId);
            builder.HasIndex(b => b.ContentImageType);

        }
    }
}
