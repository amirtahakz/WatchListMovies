using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Genre;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.FavoriteAgg.Repository;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Domain.ListAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;
using WatchListMovies.Domain.UserAgg.Repository;
using WatchListMovies.Infrastructure.ExternalApiServices.Cast;
using WatchListMovies.Infrastructure.ExternalApiServices.Genre;
using WatchListMovies.Infrastructure.ExternalApiServices.Movie;
using WatchListMovies.Infrastructure.ExternalApiServices.Tv;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Infrastructure.Persistent.Ef.CastAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.ContentCastAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.FavoriteAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.Genre;
using WatchListMovies.Infrastructure.Persistent.Ef.ListAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.MovieAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.TvAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.UserAgg;

namespace WatchListMovies.Infrastructure
{
    public class InfrastructureBootstrapper
    {
        public static void Init(IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            // Bind TMDBConfig section from appsettings.json
            services.Configure<TMDBConfig>(configuration.GetSection("TMDBConfig"));

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IFavoriteRepository, FavoriteRepository>();
            services.AddTransient<IListRepository, ListRepository>();
            services.AddTransient<IMovieRepository, MovieRepository>();
            services.AddTransient<ITvRepository, TvRepository>();
            services.AddTransient<ICastRepository, CastRepository>();
            services.AddTransient<IGenreRepository, GenreRepository>();
            services.AddTransient<IContentCastRepository, ContentCastRepository>();

            services.AddDbContext<ApplicationDbContext>(option =>
            {
                option.UseSqlServer(connectionString);
            });

            services.AddHttpClient<IMovieApiService, MovieApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<ITvApiService, TvApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<ICastApiService, CastApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<IGenreApiService, GenreApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });
        }
    }
}
