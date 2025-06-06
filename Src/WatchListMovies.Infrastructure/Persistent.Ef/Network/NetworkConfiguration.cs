using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WatchListMovies.Infrastructure.Persistent.Ef.Network
{
    public class NetworkConfiguration : IEntityTypeConfiguration<Domain.NetworkAgg.Network>
    {
        public void Configure(EntityTypeBuilder<Domain.NetworkAgg.Network> builder)
        {
            builder.ToTable("Networks", "network");
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Name);


            // Details Tbl Config
            builder.OwnsOne(b => b.NetworkDetail, md =>
            {
                md.ToTable("NetworkDetails", "network");
                md.HasKey(b => b.Id);
                md.HasIndex(b => b.ApiModelId).IsUnique();

            });
        }
    }
}
