using AutoMapper;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.ContentCastAgg;
using WatchListMovies.Domain.ContentCastAgg.Enums;
using WatchListMovies.Domain.ContentCastAgg.Repository;
using WatchListMovies.Domain.MovieAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Movie
{
    public class MovieJobs
    {
        private readonly IMovieApiService _movieApiService;
        private readonly IMapper _mapper;
        private readonly IMovieRepository _movieRepository;
        private readonly IContentCastRepository _contentCastRepository;

        public MovieJobs(
            IMovieApiService movieApiService,
            IMapper mapper,
            IMovieRepository movieRepository,
            IContentCastRepository contentCastRepository)
        {
            _movieApiService = movieApiService;
            _mapper = mapper;
            _movieRepository = movieRepository;
            _contentCastRepository = contentCastRepository;
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

                    foreach (var item in data.movies)
                    {
                        if (!apiMovies.movies.Any(v=>v.ApiModelId == item.ApiModelId))
                            apiMovies.movies.Add(item);
                    }
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
    }

}
