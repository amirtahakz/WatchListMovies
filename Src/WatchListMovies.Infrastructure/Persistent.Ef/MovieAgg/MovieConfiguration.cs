using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef.MovieAgg
{
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.ToTable("Movies", "movie");
            builder.HasIndex(b => b.ApiModelId).IsUnique();
            builder.HasIndex(b => b.Title);
            builder.HasIndex(b => b.OriginalTitle);
            builder.HasIndex(b => b.ReleaseDate);
            builder.Property(b => b.IsRecommendedByAdmin).HasDefaultValue(false);
            builder.Property(m => m.GenreIds)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .HasColumnName("GenreIds");


            // MovieDetails Tbl Config
            builder.OwnsOne(b => b.MovieDetails, md =>
            {
                md.ToTable("MovieDetails", "movie");
                md.HasKey(b => b.Id);
                md.HasIndex(b => b.ApiModelId).IsUnique();
                md.Property(m => m.GenreIds)
                    .HasConversion(
                        v => string.Join(",", v),
                        v => v.Split(',', StringSplitOptions.RemoveEmptyEntries))
                    .HasColumnName("GenreIds");


                // SpokenLanguagesVo Tbl Config
                md.OwnsMany(m => m.SpokenLanguages, sl =>
                {
                    sl.ToTable("SpokenLanguages", "movie");
                    sl.WithOwner().HasForeignKey("ParrentId");
                    sl.HasKey("CreationDate", "ParrentId", "EnglishName");
                    sl.Property(x => x.Iso6391);
                    sl.Property(x => x.Name);
                    sl.Property(x => x.EnglishName);
                    sl.Property(x => x.ParrentId);
                    sl.Property(x => x.CreationDate);

                });


                // ProductionCompaniesVo Tbl Config
                md.OwnsMany(m => m.ProductionCompanies, pc =>
                {
                    pc.ToTable("ProductionCompanies", "movie");
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
                md.OwnsMany(m => m.ProductionCountries, pc =>
                {
                    pc.ToTable("ProductionCountries", "movie");
                    pc.WithOwner().HasForeignKey("ParrentId");
                    pc.HasKey("CreationDate", "ParrentId", "Name");
                    pc.Property(x => x.Iso31661);
                    pc.Property(x => x.Name);
                    pc.Property(x => x.ParrentId);
                    pc.Property(x => x.CreationDate);

                });

                //BelongsToCollectionsVo Tbl Config
                md.OwnsOne(m => m.BelongsToCollection, btc =>
                {
                    btc.ToTable("BelongsToCollections", "movie");
                    btc.WithOwner().HasForeignKey("ParrentId");
                    btc.HasKey("CreationDate" , "ParrentId" , "Name");
                    btc.Property(x => x.BackdropPath);
                    btc.Property(x => x.Name);
                    btc.Property(x => x.BackdropPath);
                    btc.Property(x => x.CreationDate);
                    btc.Property(x => x.PosterPath);

                });

                //MovieKeyYoutubeTrailers Tbl Config
                md.OwnsMany(m => m.MovieKeyYoutubeTrailers, btc =>
                {
                    btc.ToTable("MovieKeyYoutubeTrailers", "movie");
                    btc.HasKey(b => b.Id);
                    btc.HasIndex(b => b.ApiModelId).IsUnique();

                });

            });
        }
    }
}
