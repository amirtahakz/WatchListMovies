using Hangfire;
using Microsoft.Extensions.Options;
using WatchListMovies.Application.BackgroundJobs.Cast;
using WatchListMovies.Application.BackgroundJobs.Genre;
using WatchListMovies.Application.BackgroundJobs.Movie;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Common.AspNetCore.Middlewares;

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
                recurringJobId: "SyncMovieDetails",
                methodCall: svc => svc.SyncMovieDetails(),
                cronExpression: jobSchedules.SyncMovieDetails);

            RecurringJob.AddOrUpdate<MovieJobs>(
                recurringJobId: "SyncMovieKeyYoutubeTrailers",
                methodCall: svc => svc.SyncMovieKeyYoutubeTrailers(),
                cronExpression: jobSchedules.SyncMovieKeyYoutubeTrailers);

            RecurringJob.AddOrUpdate<MovieJobs>(
                recurringJobId: "SyncCastsAndCrewsOfMovie",
                methodCall: svc => svc.SyncCastsAndCrewsOfMovie(),
                cronExpression: jobSchedules.SyncCastsAndCrewsOfMovie);

            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncPopularTvs",
                methodCall: svc => svc.SyncPopularTvs(),
                cronExpression: jobSchedules.SyncPopularTvs);

            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncTvDetails",
                methodCall: svc => svc.SyncTvDetails(),
                cronExpression: jobSchedules.SyncTvDetails);


            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncCastsAndCrewsOfTv",
                methodCall: svc => svc.SyncCastsAndCrewsOfTv(),
                cronExpression: jobSchedules.SyncCastsAndCrewsOfTv);

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

            RecurringJob.AddOrUpdate<CastJobs>(
                recurringJobId: "SyncCastImages",
                methodCall: svc => svc.SyncCastImages(),
                cronExpression: jobSchedules.SyncCastImages);

            return builder;
        }
    }
}
