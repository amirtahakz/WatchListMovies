using AutoMapper;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public class MovieJobs
    {
        private readonly IMovieApiService _movieApiService;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;

        public MovieJobs(IMovieApiService movieApiService, IMapper mapper, IMovieRepository movieRepository)
        {
            _movieApiService = movieApiService;
            _mapper = mapper;
            _movieRepository = movieRepository;
        }

        public async Task SyncPopularMovies()
        {
            try
            {
                var apiMovies = await _movieApiService.GetPopularMovies(1);
                //for (var page = 1; page <= apiMovies.TotalPages; page++)
                //{
                //    var data = await _movieApiService.GetPopularMovies(page);
                //    apiMovies.PopularTvsItemApiModelDto.AddRange(data.PopularTvsItemApiModelDto);
                //}
                for (var page = 2; page <= 3; page++)
                {
                    var data = await _movieApiService.GetPopularMovies(page);

                    apiMovies.movies.AddRange(data.movies);
                }

                await _movieRepository.AddRangeIfNotExistAsync(apiMovies.Map());
                await _movieRepository.Save();

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public async Task SyncMovieDetails()
        {

            try
            {
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Count() != 0)
                {
                    foreach (var movie in movies)
                    {
                        var apiMovieDetails = await _movieApiService.GetMovieDetails(movie.ApiModelId ?? default);
                        movie.MovieDetails = apiMovieDetails.Map(movie.Id);
                        await _movieRepository.Save();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncMovieKeyYoutubeTrailers()
        {

            try
            {
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Count() != 0)
                {
                    foreach (var movie in movies)
                    {
                        var apiMovieYoutubeTrailers = await _movieApiService.GetMovieYoutubeTrailerKeys(movie.ApiModelId ?? default);

                        foreach (var item in apiMovieYoutubeTrailers.Results)
                            movie.MovieDetails.MovieKeyYoutubeTrailers = item.Map(movie.MovieDetails.Id);

                        await _movieRepository.Save();
                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }

        public async Task SyncCastsAndCrewsOfMovie()
        {

            try
            {
                var movies = await _movieRepository.GetAllAsync();
                if (movies.Count() != 0)
                {
                    foreach (var movie in movies)
                    {
                        var apiCastsAndCrewsOfMovie = await _movieApiService.GetCastsAndCrewsOfMovie(movie.ApiModelId ?? default);

                        if (apiCastsAndCrewsOfMovie.Casts != null)
                            movie.MovieDetails.Casts.AddRange(apiCastsAndCrewsOfMovie.Casts.Map(movie.MovieDetails.Id));


                        if (apiCastsAndCrewsOfMovie.Crews != null)
                            movie.MovieDetails.Crews.AddRange(apiCastsAndCrewsOfMovie.Crews.Map(movie.MovieDetails.Id));

                        await _movieRepository.Save();

                    }
                }
            }
            catch (Exception e)
            {
                throw e;
            }

        }
    }

}
