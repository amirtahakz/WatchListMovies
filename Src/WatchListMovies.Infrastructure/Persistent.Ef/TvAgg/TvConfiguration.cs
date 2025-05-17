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


            td.OwnsMany(t => t.Genres, g =>
            {
                g.WithOwner();
                g.ToTable("Genres", "tv");
                g.Property(x => x.ApiModelId);
                g.Property(x => x.Name);
                g.Property(x => x.MediaId);
                g.Property(x => x.CreationDate);

            });

            td.OwnsMany(t => t.Networks, n =>
            {
                n.WithOwner();
                n.ToTable("Networks", "tv");
                n.Property(x => x.ApiModelId);
                n.Property(x => x.MediaId);
                n.Property(x => x.CreationDate);
                n.Property(x => x.Name);
                n.Property(x => x.OriginCountry);
                n.Property(x => x.LogoPath);
            });

            td.OwnsMany(t => t.ProductionCompanies, pc =>
            {

                pc.WithOwner();
                pc.ToTable("ProductionCompanies", "tv");
                pc.Property(x => x.ApiModelId);
                pc.Property(x => x.MediaId);
                pc.Property(x => x.CreationDate);
                pc.Property(x => x.Name);
                pc.Property(x => x.OriginCountry);
                pc.Property(x => x.LogoPath);
            });

            td.OwnsMany(t => t.ProductionCountries, c =>
            {
                c.WithOwner();
                c.ToTable("ProductionCountries", "tv");
                c.Property(x => x.MediaId);
                c.Property(x => x.CreationDate);
                c.Property(x => x.Iso31661);
                c.Property(x => x.Name);
            });

            td.OwnsMany(t => t.SpokenLanguages, sp =>
            {
                sp.WithOwner();
                sp.ToTable("SpokenLanguages", "tv");
                sp.Property(x => x.MediaId);
                sp.Property(x => x.CreationDate);
                sp.Property(x => x.Name);
                sp.Property(x => x.Iso6391);
                sp.Property(x => x.EnglishName);
            });

            td.OwnsMany(t => t.CreatedBys, cb =>
            {
                cb.WithOwner();
                cb.ToTable("CreatedBys", "tv");
                cb.Property(x => x.MediaId);
                cb.Property(x => x.CreationDate);
                cb.Property(x => x.Name);
                cb.Property(x => x.Gender);
                cb.Property(x => x.ApiModelId);
                cb.Property(x => x.OriginalName);
                cb.Property(x => x.ProfilePath);
            });

            td.OwnsMany(t => t.EpisodeToAirs, le =>
            {
                le.WithOwner();
                le.ToTable("EpisodeToAirs", "tv");
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

            td.OwnsMany(t => t.Seasons, s =>
            {
                s.WithOwner();
                s.ToTable("Seasons", "tv");
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


        });
    }
}