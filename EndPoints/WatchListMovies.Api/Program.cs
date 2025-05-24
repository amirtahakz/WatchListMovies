using AspNetCoreRateLimit;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Mvc;
using WatchListMovies.Api.Infrastructure;
using WatchListMovies.Api.Infrastructure.JwtUtil;
using WatchListMovies.Common;
using WatchListMovies.Common.Application.FileUtil.Interfaces;
using WatchListMovies.Common.Application.FileUtil.Services;
using WatchListMovies.Common.AspNetCore;
using WatchListMovies.Common.AspNetCore.Middlewares;
using System.Text.Json.Serialization;
using Hangfire;
using AngleSharp;
using WatchListMovies.Application.Configurations;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddControllers()
    .ConfigureApiBehaviorOptions(option =>
    {
        option.InvalidModelStateResponseFactory = (context =>
        {
            var result = new ApiResult()
            {
                IsSuccess = false,
                MetaData = new()
                {
                    AppStatusCode = AppStatusCode.BadRequest,
                    Message = ModelStateUtil.GetModelStateErrors(context.ModelState)
                }
            };
            return new BadRequestObjectResult(result);
        });
    })
    .AddJsonOptions(options => //This Line Shows Enums String In Swagger
    {
        options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
    }); ;
services.AddEndpointsApiExplorer();
services.AddSwaggerGen(option =>
{
    var jwtSecurityScheme = new OpenApiSecurityScheme
    {
        Scheme = "bearer",
        BearerFormat = "JWT",
        Name = "JWT Authentication",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.Http,
        Description = "Enter Token",

        Reference = new OpenApiReference
        {
            Id = JwtBearerDefaults.AuthenticationScheme,
            Type = ReferenceType.SecurityScheme
        }
    };

    option.AddSecurityDefinition(jwtSecurityScheme.Reference.Id, jwtSecurityScheme);

    option.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        { jwtSecurityScheme, Array.Empty<string>() }
    });
});
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
services.Configure<JobSchedulesConfig>(builder.Configuration.GetSection("JobSchedulesConfig"));

services.RegisterApiDependency(builder.Configuration);

CommonBootstrapper.Init(builder.Services);
services.AddTransient<IFileService, FileService>();

services.AddJwtAuthentication(builder.Configuration);


// Add Hangfire with SQL Server storage
services.AddHangfire(config =>
    config.UseSqlServerStorage(connectionString));
services.AddHangfireServer();

var app = builder.Build();


app.UseIpRateLimiting();

app.UseSwagger();

app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseCors("WatchListMoviesApi");


app.UseRouting();

app.UseAuthentication();

app.UseAuthorization();

// Enable Hangfire dashboard (optional)
//var allowedUsers = builder.Configuration.GetSection("Hangfire:AllowedUsers").Get<string[]>();
//var allowedIPs = builder.Configuration.GetSection("Hangfire:AllowedIPs").Get<string[]>();
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    //Authorization = new[] { new CustomHangfireAuthorizationFilter(allowedUsers, allowedIPs) },
    Authorization = new[] { new CustomHangfireAuthorizationFilter() },
    IsReadOnlyFunc = _ => false, // Set to true for read-only
    DarkModeEnabled = true,
});

app.UseApiCustomExceptionHandler();

app.MapControllers();

app.UseHangFireJob(app.Services);

app.Run();
