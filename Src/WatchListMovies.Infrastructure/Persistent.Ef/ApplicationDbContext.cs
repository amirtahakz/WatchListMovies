using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.CastAgg;
using WatchListMovies.Domain.FavoriteAgg;
using WatchListMovies.Domain.ListAgg;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.TvAgg;
using WatchListMovies.Domain.UserAgg;

namespace WatchListMovies.Infrastructure.Persistent.Ef
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :
            base(options)
        {
        }

       
        public DbSet<User> Users { get; set; }
        public DbSet<UserToken> UserTokens { get; set; }

        public DbSet<Favorite> Favorites { get; set; }
        public DbSet<List> Lists { get; set; }


        public DbSet<Movie> Movies { get; set; }
        public DbSet<MovieDetail> MovieDetails { get; set; }
        public DbSet<MovieKeyYoutubeTrailer> MovieKeyYoutubeTrailers { get; set; }
        public DbSet<MovieCast> MovieCasts { get; set; }
        public DbSet<MovieCrew> MovieCrews { get; set; }


        public DbSet<Tv> Tvs { get; set; }
        public DbSet<TvDetail> TvDetails { get; set; }
        public DbSet<TvCast> TvCasts { get; set; }
        public DbSet<TvCrew> TvCrews { get; set; }


        public DbSet<Cast> Casts { get; set; }
        public DbSet<CastExternalId> CastExternalIds { get; set; }
        public DbSet<CastDetail> CastDetails { get; set; }
        public DbSet<CastImage> CastImages { get; set; }


        public DbSet<Domain.GenreAgg.Genre> Genres { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.EnableSensitiveDataLogging();
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ApplicationDbContext).Assembly);
            base.OnModelCreating(modelBuilder);
            foreach (var item in modelBuilder.Model.GetEntityTypes())
            {
                var primaryKey = item.FindPrimaryKey();
                if (primaryKey == null) continue; // کلید نداشت، رد شو

                var p = primaryKey.Properties.FirstOrDefault(i => i.ValueGenerated != Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never);

                if (p != null)
                {
                    p.ValueGenerated = Microsoft.EntityFrameworkCore.Metadata.ValueGenerated.Never;
                }

            }

        }

    }

}
