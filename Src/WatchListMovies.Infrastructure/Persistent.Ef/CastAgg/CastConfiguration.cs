using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.CastAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.CastAgg
{
    public class CastConfiguration : IEntityTypeConfiguration<Cast>
    {
        public void Configure(EntityTypeBuilder<Cast> builder)
        {
            builder.ToTable("Casts", "cast");
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Gender);
            builder.HasIndex(b => b.Name);
            builder.HasIndex(b => b.OriginalName);


            // CastDetails Tbl Config
            builder.OwnsOne(b => b.CastDetails, cd =>
            {
                cd.ToTable("CastDetails", "cast");
                cd.HasKey(b => b.Id);
                cd.HasIndex(b => b.ApiModelId).IsUnique();
                cd.Property(m => m.CastAlsoKnownAss)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .HasColumnName("CastAlsoKnownAss");
            });

            // CastExternalId Tbl Config
            builder.OwnsOne(c => c.CastExternalId, castExternalIdOption =>
            {
                castExternalIdOption.ToTable("CastExternalId", "cast");
                castExternalIdOption.HasKey(b => b.Id);
                castExternalIdOption.HasIndex(b => b.ApiModelId);
                castExternalIdOption.HasIndex(b => b.CastId);
            });

            // CastKnownFors Tbl Config
            builder.OwnsMany(c => c.CastKnownFors, ckf =>
            {
                ckf.ToTable("CastKnownFors", "cast");
                ckf.HasIndex(b => b.ApiModelId);
                ckf.HasIndex(b => b.CastId);
                ckf.HasIndex(b => b.Title);
                ckf.HasIndex(b => b.OriginalTitle);

                // CastKnownForGenreId Tbl Config
                ckf.OwnsMany(c => c.CastKnownForGenreIds, gi =>
                {
                    gi.ToTable("CastKnownForGenreIds", "cast");
                });
            });

            // CastImages Tbl Config
            builder.OwnsMany(c => c.CastImages, ci =>
            {
                ci.ToTable("CastImages", "cast");
                ci.HasKey(b => b.Id);
            });
        }
    }
}
