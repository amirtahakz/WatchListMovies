using AutoMapper;
using WatchListMovies.Application.IExternalApiServices.Genre;
using WatchListMovies.Domain.GenreAgg.Repository;

namespace WatchListMovies.Application.BackgroundJobs.Genre
{
    public class GenreJobs
    {
        private readonly IGenreApiService _genreApiService;
        private readonly IGenreRepository _genreRepository;
        private readonly IMapper _mapper;

        public GenreJobs(IGenreApiService genreApiService, IGenreRepository genreRepository, IMapper mapper)
        {
            _genreApiService = genreApiService;
            _genreRepository = genreRepository;
            _mapper = mapper;
        }

        public async Task SyncGenres()
        {
            try
            {
                var apiMovieGenres = await _genreApiService.GetMovieGenres();
                var apiTvGenres = await _genreApiService.GetTvGenres();


                var result = new List<Domain.GenreAgg.Genre>();
                result.AddRange(apiMovieGenres.Map(Domain.GenreAgg.Enums.GenreType.Movie));
                result.AddRange(apiTvGenres.Map(Domain.GenreAgg.Enums.GenreType.Tv));

                await _genreRepository.AddRangeIfNotExistAsync(result);
                await _genreRepository.Save();

            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
