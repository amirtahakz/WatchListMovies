using Hangfire;
using Microsoft.Extensions.Options;
using WatchListMovies.Application.BackgroundJobs.Cast;
using WatchListMovies.Application.BackgroundJobs.Collection;
using WatchListMovies.Application.BackgroundJobs.Company;
using WatchListMovies.Application.BackgroundJobs.Configuration;
using WatchListMovies.Application.BackgroundJobs.ContentCast;
using WatchListMovies.Application.BackgroundJobs.ContentImage;
using WatchListMovies.Application.BackgroundJobs.Episode;
using WatchListMovies.Application.BackgroundJobs.Genre;
using WatchListMovies.Application.BackgroundJobs.Movie;
using WatchListMovies.Application.BackgroundJobs.Network;
using WatchListMovies.Application.BackgroundJobs.Season;
using WatchListMovies.Application.BackgroundJobs.Tv;
using WatchListMovies.Application.BackgroundJobs.Video;
using WatchListMovies.Application.Configurations;
using WatchListMovies.Common.AspNetCore.Middlewares;
using WatchListMovies.Domain.CompanyAgg;
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
                recurringJobId: "SyncMovieDetails",
                methodCall: svc => svc.SyncMovieDetails(),
                cronExpression: jobSchedules.SyncMovieDetails);

            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncPopularTvs",
                methodCall: svc => svc.SyncPopularTvs(),
                cronExpression: jobSchedules.SyncPopularTvs);

            RecurringJob.AddOrUpdate<TvJobs>(
                recurringJobId: "SyncTvDetails",
                methodCall: svc => svc.SyncTvDetails(),
                cronExpression: jobSchedules.SyncTvDetails);

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
                recurringJobId: "SyncCastImages",
                methodCall: svc => svc.SyncCastImages(),
                cronExpression: jobSchedules.SyncCastImages);

            RecurringJob.AddOrUpdate<ContentImageJobs>(
                recurringJobId: "SyncTvImages",
                methodCall: svc => svc.SyncTvImages(),
                cronExpression: jobSchedules.SyncTvImages);

            RecurringJob.AddOrUpdate<ContentImageJobs>(
                recurringJobId: "SyncMovieImages",
                methodCall: svc => svc.SyncMovieImages(),
                cronExpression: jobSchedules.SyncMovieImages);

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


            RecurringJob.AddOrUpdate<CompanyJobs>(
                recurringJobId: "SyncCompanyDetails",
                methodCall: svc => svc.SyncCompanyDetails(),
                cronExpression: jobSchedules.SyncCompanyDetails);


            RecurringJob.AddOrUpdate<CompanyJobs>(
                recurringJobId: "SyncMovieCompanies",
                methodCall: svc => svc.SyncMovieCompanies(),
                cronExpression: jobSchedules.SyncMovieCompanies);

            RecurringJob.AddOrUpdate<CompanyJobs>(
                recurringJobId: "SyncTvCompanies",
                methodCall: svc => svc.SyncTvCompanies(),
                cronExpression: jobSchedules.SyncTvCompanies);


            RecurringJob.AddOrUpdate<CollectionJobs>(
                recurringJobId: "SyncCollections",
                methodCall: svc => svc.SyncCollections(),
                cronExpression: jobSchedules.SyncCollections);


            RecurringJob.AddOrUpdate<CollectionJobs>(
                recurringJobId: "SyncCollectionDetails",
                methodCall: svc => svc.SyncCollectionDetails(),
                cronExpression: jobSchedules.SyncCollectionDetails);

            RecurringJob.AddOrUpdate<NetworkJobs>(
                recurringJobId: "SyncNetworks",
                methodCall: svc => svc.SyncNetworks(),
                cronExpression: jobSchedules.SyncCollectionDetails);

            RecurringJob.AddOrUpdate<NetworkJobs>(
                recurringJobId: "SyncNetworkDetails",
                methodCall: svc => svc.SyncNetworkDetails(),
                cronExpression: jobSchedules.SyncNetworkDetails);


            RecurringJob.AddOrUpdate<SeasonJobs>(
                recurringJobId: "SyncSeasons",
                methodCall: svc => svc.SyncSeasons(),
                cronExpression: jobSchedules.SyncNetworkDetails);


            RecurringJob.AddOrUpdate<EpisodeJobs>(
                recurringJobId: "SyncEpisodes",
                methodCall: svc => svc.SyncEpisodes(),
                cronExpression: jobSchedules.SyncEpisodes);

            RecurringJob.AddOrUpdate<VideoJobs>(
                recurringJobId: "SyncMovieVideos",
                methodCall: svc => svc.SyncMovieVideos(),
                cronExpression: jobSchedules.SyncEpisodes);

            RecurringJob.AddOrUpdate<VideoJobs>(
                recurringJobId: "SyncTvVideos",
                methodCall: svc => svc.SyncTvVideos(),
                cronExpression: jobSchedules.SyncTvVideos);


            return builder;
        }
    }
}
