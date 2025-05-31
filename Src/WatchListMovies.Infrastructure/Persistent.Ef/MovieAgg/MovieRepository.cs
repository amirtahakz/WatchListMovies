using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Domain.UserAgg;
using WatchListMovies.Infrastructure._Utilities;
using EFCore.BulkExtensions;

namespace WatchListMovies.Infrastructure.Persistent.Ef.MovieAgg
{
    public class MovieRepository : BaseRepository<Movie>, IMovieRepository
    {
        public MovieRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<List<Movie>> GetAllAsync()
        {
            var result = await Context.Movies
                .AsTracking()
                .ToListAsync();
            return result;
        }

        public async Task<List<Movie>> GetAllAsNoTrackingAsync()
        {
            var result = await Context.Movies.AsNoTracking().ToListAsync();
            return result;
        }
        public async Task<bool> DeleteAllAsync()
        {
            try
            {
                var genres = await Context.Movies.AsTracking().ToListAsync();
                Context.Movies.RemoveRange(genres);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public async Task<Movie> GetTrackingByImdbIdAsync(string imdbId)
        {
            var result = await Context.Movies
                .AsTracking()
                .Include(c=>c.MovieDetails)
                .FirstOrDefaultAsync(x=>x.MovieDetails.ImdbId == imdbId);

            return result;
        }

        public async Task AddRangeIfNotExistAsync(List<Movie> movies)
        {

            foreach (var item in movies)
            {
                var existingMovie = await Context.Movies.FirstOrDefaultAsync(m => m.ApiModelId == item.ApiModelId);

                if (existingMovie == null)
                    await Context.Movies.AddRangeAsync(item);


            }

        }

    }

}
