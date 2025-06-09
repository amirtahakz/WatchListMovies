using AngleSharp.Dom;
using System.Linq.Expressions;
using WatchListMovies.Common.Domain;

namespace WatchListMovies.Common.Domain.Repository
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        Task<T?> GetAsync(Guid id);

        Task<T?> GetTracking(Guid id);

        Task AddAsync(T entity);
        void Add(T entity);

        Task AddRange(ICollection<T> entities);

        void Update(T entity);


        Task<int> Save();

        Task<bool> ExistsAsync(Expression<Func<T, bool>> expression);

        bool Exists(Expression<Func<T, bool>> expression);

        T? Get(Guid id);

        Task BulkInsertAsync(IEnumerable<T> data, string tableName, string connectionString, Dictionary<string, string>? columnMappings = null);

    }
}
