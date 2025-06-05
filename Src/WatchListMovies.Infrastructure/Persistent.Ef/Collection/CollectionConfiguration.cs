using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WatchListMovies.Infrastructure.Persistent.Ef.Collection
{
    public class CollectionConfiguration : IEntityTypeConfiguration<Domain.CollectionAgg.Collection>
    {
        public void Configure(EntityTypeBuilder<Domain.CollectionAgg.Collection> builder)
        {
            builder.ToTable("Collections", "collection");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Name);

            builder.OwnsOne(b => b.CollectionDetail, cd =>
            {
                cd.ToTable("CollectionDetails", "collection");
                cd.HasKey(b => b.Id);
                cd.HasIndex(b => b.ApiModelId).IsUnique();
            });
        }
    }
}
