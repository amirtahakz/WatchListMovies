using Hangfire;
using Microsoft.Extensions.Options;
using WatchListMovies.Application.BackgroundJobs.Cast;
using WatchListMovies.Application.BackgroundJobs.Configuration;
using WatchListMovies.Application.BackgroundJobs.ContentCast;
using WatchListMovies.Application.BackgroundJobs.ContentImage;
using WatchListMovies.Application.BackgroundJobs.Genre;
using WatchListMovies.Application.BackgroundJobs.Movie;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Common.AspNetCore.Middlewares;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentImageAgg;

namespace WatchListMovies.Api.Infrastructure
{
    public static class JobRegister
    {
        public static IApplicationBuilder UseHangFireJob(this IApplicationBuilder builder, IServiceProvider services)
        {
            // Retrieve JobSchedules configuration
            var jobSchedules = services.GetRequiredService<IOptions<JobSchedulesConfig>>().Value;


            //// 🔁 Recurring jobs

            RecurringJob.AddOrUpdate<MovieJobs>(
                recurringJobId: "SyncPopularMovies",
                methodCall: svc => svc.SyncPopularMovies(),
                cronExpression: jobSchedules.SyncPopularMovies);

            RecurringJob.AddOrUpdate<MovieJobs>(
                recurringJobId: "SyncMovieDetailsAndCompanies",
                methodCall: svc => svc.SyncMovieDetailsAndCompanies(),
                cronExpression: jobSchedules.SyncMovieDetailsAndCompanies);

            RecurringJob.AddOrUpdate<MovieJobs>(
                recurringJobId: "SyncMovieKeyYoutubeTrailers",
                methodCall: svc => svc.SyncMovieKeyYoutubeTrailers(),
                cronExpression: jobSchedules.SyncMovieKeyYoutubeTrailers);

            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncPopularTvs",
                methodCall: svc => svc.SyncPopularTvs(),
                cronExpression: jobSchedules.SyncPopularTvs);

            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncTvDetailsAndCompanies",
                methodCall: svc => svc.SyncTvDetailsAndCompanies(),
                cronExpression: jobSchedules.SyncTvDetailsAndCompanies);

            RecurringJob.AddOrUpdate<CastJobs>(
                recurringJobId: "SyncPopularCasts",
                methodCall: svc => svc.SyncPopularCasts(),
                cronExpression: jobSchedules.SyncPopularCasts);

            RecurringJob.AddOrUpdate<CastJobs>(
                recurringJobId: "SyncCastDetails",
                methodCall: svc => svc.SyncCastDetails(),
                cronExpression: jobSchedules.SyncCastDetails);

            RecurringJob.AddOrUpdate<CastJobs>(
                recurringJobId: "SyncCastExternalIds",
                methodCall: svc => svc.SyncCastExternalIds(),
                cronExpression: jobSchedules.SyncCastExternalIds);

            RecurringJob.AddOrUpdate<GenreJobs>(
                recurringJobId: "SyncGenres",
                methodCall: svc => svc.SyncGenres(),
                cronExpression: jobSchedules.SyncGenres);

            RecurringJob.AddOrUpdate<ContentImageJobs>(
                recurringJobId: "SyncContentImages",
                methodCall: svc => svc.SyncContentImages(),
                cronExpression: jobSchedules.SyncContentImages);

            RecurringJob.AddOrUpdate<ContentCastJobs>(
                recurringJobId: "SyncContentCasts",
                methodCall: svc => svc.SyncContentCasts(),
                cronExpression: jobSchedules.SyncContentCasts);

            RecurringJob.AddOrUpdate<ConfigurationJobs>(
                recurringJobId: "SyncCountries",
                methodCall: svc => svc.SyncCountries(),
                cronExpression: jobSchedules.SyncCountries);

            RecurringJob.AddOrUpdate<ConfigurationJobs>(
                recurringJobId: "SyncLanguages",
                methodCall: svc => svc.SyncLanguages(),
                cronExpression: jobSchedules.SyncLanguages);


            return builder;
        }
    }
}
