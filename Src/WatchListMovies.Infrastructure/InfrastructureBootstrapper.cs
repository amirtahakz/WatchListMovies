using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Net.Http.Headers;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Application.IExternalApiServices.Cast;
using WatchListMovies.Application.IExternalApiServices.Collection;
using WatchListMovies.Application.IExternalApiServices.Company;
using WatchListMovies.Application.IExternalApiServices.Configuration;
using WatchListMovies.Application.IExternalApiServices.Genre;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Network;
using WatchListMovies.Application.IExternalApiServices.Season;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Application.IExternalApiServices.Video;
using WatchListMovies.Domain.CastAgg.Repository;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.ContentImageAgg.Repository;
using WatchListMovies.Domain.CountryAgg.Repository;
using WatchListMovies.Domain.EpisodeAgg.Repository;
using WatchListMovies.Domain.FavoriteAgg.Repository;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Domain.LanguageAgg.Repository;
using WatchListMovies.Domain.ListAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.NetworkAgg.Repository;
using WatchListMovies.Domain.SeasonAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;
using WatchListMovies.Domain.UserAgg.Repository;
using WatchListMovies.Domain.VideoAgg.Repository;
using WatchListMovies.Infrastructure.ExternalApiServices.Cast;
using WatchListMovies.Infrastructure.ExternalApiServices.Collection;
using WatchListMovies.Infrastructure.ExternalApiServices.Company;
using WatchListMovies.Infrastructure.ExternalApiServices.Configuration;
using WatchListMovies.Infrastructure.ExternalApiServices.Genre;
using WatchListMovies.Infrastructure.ExternalApiServices.Movie;
using WatchListMovies.Infrastructure.ExternalApiServices.Network;
using WatchListMovies.Infrastructure.ExternalApiServices.Season;
using WatchListMovies.Infrastructure.ExternalApiServices.Tv;
using WatchListMovies.Infrastructure.ExternalApiServices.Video;
using WatchListMovies.Infrastructure.Persistent.Ef;
using WatchListMovies.Infrastructure.Persistent.Ef.CastAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.CollectionAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.CompanyAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.ContentCastAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.ContentImageAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.CountryAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.EpisodeAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.FavoriteAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.GenreAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.LanguageAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.ListAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.MovieAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.NetworkAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.SeasonAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.TvAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.UserAgg;
using WatchListMovies.Infrastructure.Persistent.Ef.VideoAgg;

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
            services.AddTransient<IContentImageRepository, ContentImageRepository>();
            services.AddTransient<ICountryRepository, CountryRepository>();
            services.AddTransient<ILanguageRepository, LanguageRepository>();
            services.AddTransient<ICompanyRepository, CompanyRepository>();
            services.AddTransient<ICollectionRepository, CollectionRepository>();
            services.AddTransient<INetworkRepository, NetworkRepository>();
            services.AddTransient<ISeasonRepository, SeasonRepository>();
            services.AddTransient<IEpisodeRepository, EpisodeRepository>();
            services.AddTransient<IVideoRepository, VideoRepository>();

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

            services.AddHttpClient<IConfigurationApiService, ConfigurationApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<ICompanyApiService, CompanyApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<ICollectionApiService, CollectionApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<INetworkApiService, NetworkApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<ISeasonApiService, SeasonApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });

            services.AddHttpClient<IVideoApiService, VideoApiService>(client =>
            {
                client.BaseAddress = new Uri(configuration["TMDBConfig:BaseAddress"] ?? "");
            });
        }
    }
}
