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


            // GenresVo Tbl Config
            td.OwnsMany(m => m.Genres, g =>
            {
                g.ToTable("Genres", "tv");
                g.WithOwner().HasForeignKey("MediaId");
                g.HasKey("CreationDate", "MediaId", "Name");
                g.Property(x => x.ApiModelId);
                g.Property(x => x.Name);
                g.Property(x => x.MediaId);
                g.Property(x => x.CreationDate);

            });

            //NetworksVo Tbl Config
            td.OwnsMany(t => t.Networks, n =>
            {
                n.WithOwner().HasForeignKey("MediaId");
                n.ToTable("Networks", "tv");
                n.HasKey("CreationDate" , "MediaId" , "Name");
                n.Property(x => x.ApiModelId);
                n.Property(x => x.MediaId);
                n.Property(x => x.CreationDate);
                n.Property(x => x.Name);
                n.Property(x => x.OriginCountry);
                n.Property(x => x.LogoPath);
            });

            // ProductionCompaniesVo Tbl Config
            td.OwnsMany(m => m.ProductionCompanies, pc =>
            {
                pc.ToTable("ProductionCompanies", "tv");
                pc.WithOwner().HasForeignKey("MediaId");
                pc.HasKey("CreationDate", "MediaId", "Name");
                pc.Property(x => x.ApiModelId);
                pc.Property(x => x.Name);
                pc.Property(x => x.LogoPath);
                pc.Property(x => x.OriginCountry);
                pc.Property(x => x.MediaId);
                pc.Property(x => x.CreationDate);

            });

            // ProductionCountriesVo Tbl Config
            td.OwnsMany(m => m.ProductionCountries, pc =>
            {
                pc.ToTable("ProductionCountries", "tv");
                pc.WithOwner().HasForeignKey("MediaId");
                pc.HasKey("CreationDate", "MediaId", "Name");
                pc.Property(x => x.Iso31661);
                pc.Property(x => x.Name);
                pc.Property(x => x.MediaId);
                pc.Property(x => x.CreationDate);

            });

            // SpokenLanguagesVo Tbl Config
            td.OwnsMany(m => m.SpokenLanguages, sl =>
            {
                sl.ToTable("SpokenLanguages", "tv");
                sl.WithOwner().HasForeignKey("MediaId");
                sl.HasKey("CreationDate", "MediaId", "EnglishName");
                sl.Property(x => x.Iso6391);
                sl.Property(x => x.Name);
                sl.Property(x => x.EnglishName);
                sl.Property(x => x.MediaId);
                sl.Property(x => x.CreationDate);

            });

            //CreatedBysVo Tbl Config
            td.OwnsMany(t => t.CreatedBys, cb =>
            {
                cb.ToTable("CreatedBys", "tv");
                cb.WithOwner().HasForeignKey("MediaId");
                cb.HasKey("CreationDate", "MediaId", "Name");
                cb.Property(x => x.MediaId);
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
                le.WithOwner().HasForeignKey("MediaId");
                le.HasKey("CreationDate", "MediaId", "Name");
                le.Property(x => x.MediaId);
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
                s.WithOwner().HasForeignKey("MediaId");
                s.HasKey("CreationDate", "MediaId", "Name");
                s.Property(x => x.Name);
                s.Property(x => x.AirDate);
                s.Property(x => x.EpisodeCount);
                s.Property(x => x.SeasonNumber);
                s.Property(x => x.PosterPath);
                s.Property(x => x.VoteAverage);
                s.Property(x => x.CreationDate);
                s.Property(x => x.MediaId);
                s.Property(x => x.Overview);
                s.Property(x => x.ApiModelId);
            });

            //TvCasts Tbl Config
            td.OwnsMany(m => m.Casts, btc =>
            {
                btc.ToTable("TvCasts", "tv");
                btc.HasKey(b => b.Id);
                btc.HasIndex(b => b.ApiModelId);

            });

            //TvCrews Tbl Config
            td.OwnsMany(m => m.Crews, btc =>
            {
                btc.ToTable("TvCrews", "tv");
                btc.HasKey(b => b.Id);
                btc.HasIndex(b => b.ApiModelId);

            });


        });
    }
}