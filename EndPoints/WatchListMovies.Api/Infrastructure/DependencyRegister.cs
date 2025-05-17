using AspNetCoreRateLimit;
using FluentValidation;
using Hangfire;
using MediatR;
using WatchListMovies.Api.Infrastructure.JwtUtil;
using WatchListMovies.Application._Utilities;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Application.Services.Users.Create;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Infrastructure;
using WatchListMovies.Query.Users.GetById;
using IConfiguration = Microsoft.Extensions.Configuration.IConfiguration;

namespace WatchListMovies.Api.Infrastructure;

public static class DependencyRegister
{
    public static void RegisterApiDependency(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("DefaultConnection");

        InfrastructureBootstrapper.Init(services, configuration);

        services.AddMediatR(typeof(Directories).Assembly);

        services.AddMediatR(typeof(GetUserByIdQuery).Assembly);




        services.AddValidatorsFromAssembly(typeof(CreateUserCommandValidator).Assembly);


        services.AddAutoMapper(typeof(MapperProfile).Assembly);
        services.AddAutoMapper(typeof(PopularMoviesItem).Assembly);
        services.AddAutoMapper(typeof(Movie).Assembly);
        services.AddTransient<CustomJwtValidation>();

        services.AddCors(options =>
        {
            options.AddPolicy(name: "WatchListMoviesApi",
                builder =>
                {
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                });
        });
        services.AddMemoryCache();

        //load general configuration from appsettings.json
        services.Configure<IpRateLimitOptions>(configuration.GetSection("IpRateLimiting"));

        //load ip rules from appsettings.json
        services.Configure<IpRateLimitPolicies>(configuration.GetSection("IpRateLimitPolicies"));

        // inject counter and rules stores
        services.AddInMemoryRateLimiting();

        services.AddSingleton<IRateLimitConfiguration, RateLimitConfiguration>();

    }
}