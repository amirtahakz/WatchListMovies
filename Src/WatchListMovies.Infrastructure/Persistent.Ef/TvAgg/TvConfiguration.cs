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



            //EpisodeToAirsVo Tbl Config
            td.OwnsMany(t => t.EpisodeToAirs, le =>
            {
                le.ToTable("EpisodeToAirs", "tv");
                le.WithOwner().HasForeignKey("ParrentId");
                le.HasKey("CreationDate", "ParrentId", "Name");
                le.Property(x => x.ParrentId);
                le.Property(x => x.CreationDate);
                le.Property(x => x.Name);
                le.Property(x => x.ApiModelId);
                le.Property(x => x.Overview);
                le.Property(x => x.AirDate);
                le.Property(x => x.EpisodeNumber);
                le.Property(x => x.SeasonNumber);
                le.Property(x => x.EpisodeType);
                le.Property(x => x.EpisodeAirType);
                le.Property(x => x.StillPath);
                le.Property(x => x.VoteAverage);
                le.Property(x => x.VoteCount);

            });

            //SeasonsVo Tbl Config
            td.OwnsMany(t => t.Seasons, s =>
            {
                s.ToTable("Seasons", "tv");
                s.WithOwner().HasForeignKey("ParrentId");
                s.HasKey("CreationDate", "ParrentId", "Name");
                s.Property(x => x.Name);
                s.Property(x => x.AirDate);
                s.Property(x => x.EpisodeCount);
                s.Property(x => x.SeasonNumber);
                s.Property(x => x.PosterPath);
                s.Property(x => x.VoteAverage);
                s.Property(x => x.CreationDate);
                s.Property(x => x.ParrentId);
                s.Property(x => x.Overview);
                s.Property(x => x.ApiModelId);
            });


        });
    }
}