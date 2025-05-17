using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using WatchListMovies.Common.Application;
using WatchListMovies.Domain.ListAgg.Repository;
using WatchListMovies.Domain.MovieAgg;

namespace WatchListMovies.Application.Services.Movie.Create
{
    public class CreateMovieCommand : IBaseCommand<Guid>
    {
        public bool? Adult { get; set; }
        public string? BackdropPath { get; set; }
        public long? ApiModelId { get; set; }
        public string? OriginalLanguage { get; set; }
        public string? OriginalTitle { get; set; }
        public string? Overview { get; set; }
        public double? Popularity { get; set; }
        public string? PosterPath { get; set; }
        public string? ReleaseDate { get; set; }
        public string? Title { get; set; }
        public bool? Video { get; set; }
        public double? VoteAverage { get; set; }
        public int? VoteCount { get; set; }
        public MovieDetail? MovieDetails { get; set; }
    }



}
