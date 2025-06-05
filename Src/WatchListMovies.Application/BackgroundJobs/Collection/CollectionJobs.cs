using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices._Shared;
using WatchListMovies.Application.IExternalApiServices.Collection;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Tv;
using WatchListMovies.Domain.CollectionAgg.Repository;
using WatchListMovies.Domain.CompanyAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.TvAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Collection
{
    public class CollectionJobs
    {
        private readonly ICollectionApiService _collectionApiService;
        private readonly ICollectionRepository _collectionRepository;
        private readonly IMovieRepository _movieRepository;
        private readonly IMovieApiService _movieApiService;

        public CollectionJobs(
            ICollectionApiService collectionApiService,
            ICollectionRepository collectionRepository,
            IMovieRepository movieRepository,
            IMovieApiService movieApiService)
        {
            _collectionApiService = collectionApiService;
            _collectionRepository = collectionRepository;
            _movieRepository = movieRepository;
            _movieApiService = movieApiService;
        }

        public async Task SyncCollections()
        {
            try
            {
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Any())
                {
                    foreach (var movie in movies)
                    {
                        var apiMovieDetails = await _movieApiService.GetMovieDetails(movie.ApiModelId ?? default);
                        if (apiMovieDetails.BelongsToCollection != null) 
                        {
                            await _collectionRepository.AddIfNotExistAsync(apiMovieDetails.BelongsToCollection.Map());
                            await _collectionRepository.Save();
                        }
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncCollectionDetails()
        {
            try
            {


            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }
}
