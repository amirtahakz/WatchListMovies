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


            // MovieDetails Tbl Config
            builder.OwnsOne(b => b.MovieDetails, md =>
            {
                md.ToTable("MovieDetails", "movie");
                md.HasKey(b => b.Id);
                md.HasIndex(b => b.ApiModelId).IsUnique();


                // Genres Tbl Config
                md.OwnsMany(m => m.Genres, g =>
                {
                    g.WithOwner();
                    g.ToTable("Genres", "movie");
                    g.Property(x => x.ApiModelId);
                    g.Property(x => x.Name);
                    g.Property(x => x.MediaId);
                    g.Property(x => x.CreationDate);

                });

                // SpokenLanguages Tbl Config
                md.OwnsMany(m => m.SpokenLanguages, sl =>
                {
                    sl.WithOwner();
                    sl.ToTable("SpokenLanguages", "movie");
                    sl.Property(x => x.Iso6391);
                    sl.Property(x => x.Name);
                    sl.Property(x => x.EnglishName);
                    sl.Property(x => x.MediaId);
                    sl.Property(x => x.CreationDate);

                });


                // ProductionCompanies Tbl Config
                md.OwnsMany(m => m.ProductionCompanies, pc =>
                {
                    pc.WithOwner();
                    pc.ToTable("ProductionCompanies", "movie");
                    pc.Property(x => x.ApiModelId);
                    pc.Property(x => x.Name);
                    pc.Property(x => x.LogoPath);
                    pc.Property(x => x.OriginCountry);
                    pc.Property(x => x.MediaId);
                    pc.Property(x => x.CreationDate);

                });


                // ProductionCountries Tbl Config
                md.OwnsMany(m => m.ProductionCountries, pc =>
                {
                    pc.WithOwner();
                    pc.ToTable("ProductionCountries", "movie");
                    pc.Property(x => x.Iso31661);
                    pc.Property(x => x.Name);
                    pc.Property(x => x.MediaId);
                    pc.Property(x => x.CreationDate);

                });
                
                md.OwnsOne(m => m.BelongsToCollection, btc =>
                {
                    btc.WithOwner();
                    btc.ToTable("BelongsToCollections", "movie");
                    btc.Property(x => x.BackdropPath);
                    btc.Property(x => x.Name);
                    btc.Property(x => x.BackdropPath);
                    btc.Property(x => x.CreationDate);
                    btc.Property(x => x.PosterPath);

                });

                
            });
        }
    }
}
