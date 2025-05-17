using AutoMapper;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Domain.MovieAgg;
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
                //    apiMovies.Results.AddRange(data.Results);
                //}
                for (var page = 2; page <= 2; page++)
                {
                    var data = await _movieApiService.GetPopularMovies(page);
                    apiMovies.Results.AddRange(data.Results);
                }
                var isDeleted = await _movieRepository.DeleteAllAsync();
                await _movieRepository.Save();
                if (isDeleted)
                {
                    
                    //await _movieRepository.AddRange(_mapper.Map<List<Domain.MovieAgg.Movie>>(apiMovies.Results));
                    await _movieRepository.AddRange(apiMovies.Map());
                    await _movieRepository.Save();
                }
                    

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
                        //movie.MovieDetails = _mapper.Map<MovieDetail>(apiMovieDetails);
                        //movie.MovieDetails.MovieId = movie.Id;
                        //movie.MovieDetails.Genres.ForEach(c => c.MediaId = movie.MovieDetails.Id);
                        //movie.MovieDetails.ProductionCompanies.ForEach(c => c.MediaId = movie.MovieDetails.Id);
                        //movie.MovieDetails.ProductionCountries.ForEach(c => c.MediaId = movie.MovieDetails.Id);
                        //movie.MovieDetails.SpokenLanguages.ForEach(c => c.MediaId = movie.MovieDetails.Id);
                        //if (movie.MovieDetails.BelongsToCollection != null)
                        //    movie.MovieDetails.BelongsToCollection.MovieDetailId = movie.MovieDetails.Id;
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
