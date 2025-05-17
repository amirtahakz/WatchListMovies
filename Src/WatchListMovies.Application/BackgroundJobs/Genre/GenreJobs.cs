using AutoMapper;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WatchListMovies.Application.IExternalApiServices.Genre;
using WatchListMovies.Application.IExternalApiServices.Movie;
using WatchListMovies.Application.IExternalApiServices.Movie.ApiModelDTOs;
using WatchListMovies.Domain.GenreAgg;
using WatchListMovies.Domain.GenreAgg.Repository;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.MovieAgg.Repository;

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

                await _genreRepository.DeleteAllAsync();
                await _genreRepository.Save();
                await _genreRepository.AddRange(result);
                await _genreRepository.Save();

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
