using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchListMovies.Domain.CompanyAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CompanyAgg
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.ToTable("Companies", "company");
            builder.HasKey(b => b.Id);
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Name);

            builder.OwnsOne(b => b.CompanyDetail, cd =>
            {
                cd.ToTable("CompanyDetails", "company");
                cd.HasKey(b => b.Id);
                cd.HasIndex(b => b.ApiModelId).IsUnique();
            });
        }
    }
}
