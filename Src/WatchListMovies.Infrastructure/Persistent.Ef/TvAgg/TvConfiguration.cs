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


            //NetworksVo Tbl Config
            td.OwnsMany(t => t.Networks, n =>
            {
                n.WithOwner().HasForeignKey("ParrentId");
                n.ToTable("Networks", "tv");
                n.HasKey("CreationDate" , "ParrentId" , "Name");
                n.Property(x => x.ApiModelId);
                n.Property(x => x.ParrentId);
                n.Property(x => x.CreationDate);
                n.Property(x => x.Name);
                n.Property(x => x.OriginCountry);
                n.Property(x => x.LogoPath);
            });

            // ProductionCompaniesVo Tbl Config
            td.OwnsMany(m => m.ProductionCompanies, pc =>
            {
                pc.ToTable("ProductionCompanies", "tv");
                pc.WithOwner().HasForeignKey("ParrentId");
                pc.HasKey("CreationDate", "ParrentId", "Name");
                pc.Property(x => x.ApiModelId);
                pc.Property(x => x.Name);
                pc.Property(x => x.LogoPath);
                pc.Property(x => x.OriginCountry);
                pc.Property(x => x.ParrentId);
                pc.Property(x => x.CreationDate);

            });

            // ProductionCountriesVo Tbl Config
            td.OwnsMany(m => m.ProductionCountries, pc =>
            {
                pc.ToTable("ProductionCountries", "tv");
                pc.WithOwner().HasForeignKey("ParrentId");
                pc.HasKey("CreationDate", "ParrentId", "Name");
                pc.Property(x => x.Iso31661);
                pc.Property(x => x.Name);
                pc.Property(x => x.ParrentId);
                pc.Property(x => x.CreationDate);

            });

            // SpokenLanguagesVo Tbl Config
            td.OwnsMany(m => m.SpokenLanguages, sl =>
            {
                sl.ToTable("SpokenLanguages", "tv");
                sl.WithOwner().HasForeignKey("ParrentId");
                sl.HasKey("CreationDate", "ParrentId", "EnglishName");
                sl.Property(x => x.Iso6391);
                sl.Property(x => x.Name);
                sl.Property(x => x.EnglishName);
                sl.Property(x => x.ParrentId);
                sl.Property(x => x.CreationDate);

            });

            //CreatedBysVo Tbl Config
            td.OwnsMany(t => t.CreatedBys, cb =>
            {
                cb.ToTable("CreatedBys", "tv");
                cb.WithOwner().HasForeignKey("ParrentId");
                cb.HasKey("CreationDate", "ParrentId", "Name");
                cb.Property(x => x.ParrentId);
                cb.Property(x => x.CreationDate);
                cb.Property(x => x.Name);
                cb.Property(x => x.Gender);
                cb.Property(x => x.ApiModelId);
                cb.Property(x => x.OriginalName);
                cb.Property(x => x.ProfilePath);
            });

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