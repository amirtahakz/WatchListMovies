using Microsoft.Extensions.DependencyInjection;
using WatchListMovies.Domain.UserAgg.Repository;
using WatchListMovies.Infrastructure.Persistent.Ef.UserAgg;
using WatchListMovies.Infrastructure.Persistent.Ef;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.FavoriteAgg.Repository;
using WatchListMovies.Domain.ListAgg.Repository;
using WatchListMovies.Infrastructure.Persistent.Ef.FavoriteAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.ListAgg;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;
using WatchListMovies.Infrastructure.Persistent.Ef.MovieAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.TvAgg;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Infrastructure.Persistent.Ef.CastAgg;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Infrastructure.Persistent.Ef.Genre;
using Microsoft.Extensions.Configuration;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Infrastructure.ExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Movie;
using System.Net.Http.Headers;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Application.IExternalApiServices.Genre;
using WatchListMovies.Infrastructure.ExternalApiServices.Cast;
using WatchListMovies.Infrastructure.ExternalApiServices.Genre;
using WatchListMovies.Infrastructure.ExternalApiServices.Tv;

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
