using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WatchListMovies.Domain.TvAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.TvAgg;

public class TvConfiguration : IEntityTypeConfiguration<Tv>
{
    public void Configure(EntityTypeBuilder<Tv> builder)
    {
        builder.ToTable("Tvs", "tv");
        builder.HasIndex(b => b.ApiModelId).IsUnique();
        builder.HasIndex(b => b.Name);
        builder.HasIndex(b => b.OriginalName);
        builder.Property(b => b.IsRecommendedByAdmin).HasDefaultValue(false);
        builder.Property(b => b.GenreIds)
                .HasConversion(
                    v => string.Join(",", v),
                    v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                .HasColumnName("GenreIds");


        // TvDetails Tbl Config
        builder.OwnsOne(b => b.TvDetail, td =>
        {
            td.ToTable("TvDetails", "tv");
            td.HasKey(b => b.Id);
            td.HasIndex(b => b.ApiModelId).IsUnique();

            td.Property(m => m.TvEpisodeRunTimes)
                     .HasConversion(
                         v => string.Join(",", v),
                         v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                     .HasColumnName("TvEpisodeRunTimes");

            td.Property(m => m.GenreIds)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .HasColumnName("GenreIds");

            td.Property(m => m.CompanyIds)
                   .HasConversion(
                       v => string.Join(",", v),
                       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                   .HasColumnName("CompanyIds");

            td.Property(m => m.LanguageIds)
               .HasConversion(
                   v => string.Join(",", v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
               .HasColumnName("LanguageIds");

            td.Property(m => m.CountryIds)
               .HasConversion(
                   v => string.Join(",", v),
                   v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
               .HasColumnName("CountryIds");

            td.Property(m => m.CreatedByIds)
                   .HasConversion(
                       v => string.Join(",", v),
                       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                   .HasColumnName("CreatedByIds");

            td.Property(m => m.NetworkIds)
                   .HasConversion(
                       v => string.Join(",", v),
                       v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                   .HasColumnName("NetworkIds");

        });
    }
}