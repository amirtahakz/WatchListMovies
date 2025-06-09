using Microsoft.EntityFrameworkCore;
using WatchListMovies.Domain.MovieAgg;
using WatchListMovies.Domain.MovieAgg.Repository;
using WatchListMovies.Infrastructure._Utilities;
using EFCore.BulkExtensions;
using Microsoft.Extensions.Configuration;

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
                await AddIfNotExistAsync(item);

        }
        
        public async Task AddIfNotExistAsync(Movie movie)
        {
            var isExist = await Context.Movies.AnyAsync(m => m.ApiModelId == movie.ApiModelId);

            if (!isExist)
                await Context.Movies.AddAsync(movie);
        }
        public async Task BulkInsertIfNotExistAsync(List<Movie> movies)
        {
            var uniqueMovies = movies.GroupBy(p => p.ApiModelId).Where(g => g.Count() == 1).Select(g => g.First()).ToList();

            var apiModelIds = uniqueMovies.Select(d => d.ApiModelId).ToList();

            // گرفتن ApiModelIdهایی که در دیتابیس موجود هستند
            var existingApiIds = await Context.Movies
                .Where(m => apiModelIds.Contains(m.ApiModelId))
                .Select(m => m.ApiModelId)
                .ToListAsync();

            // فیلتر کردن فقط داده‌هایی که وجود ندارند
            var newMovies = uniqueMovies.Where(dto => !existingApiIds.Contains(dto.ApiModelId)).ToList();

            // درج جدیدها
            if (newMovies.Any())
                await Context.BulkInsertAsync(newMovies);

        }

        public async Task BulkInsertOrUpdateAsync(List<Movie> movies)
        {
            await Context.BulkInsertOrUpdateAsync(movies, new BulkConfig
            {
                IncludeGraph = true, // فقط اگر MovieDetails داخل خود Movie قرار دارن
                PreserveInsertOrder = true,
                SetOutputIdentity = true
            });
        }

        public async Task<long> GetCountAsync()
        {
            return await Context.Movies.CountAsync();
        }

        public async Task<List<Movie>> GetBatchAsync(int skip, int take)
        {
            return await Context.Movies
                        .AsNoTracking()
                        .OrderBy(m => m.Id)
                        .Skip(skip)
                        .Take(take)
                        .ToListAsync();
        }
    }

}
