using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Infrastructure.Persistent.Ef;

namespace WatchListMovies.Infrastructure._Utilities
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : Common.Domain.BaseEntity
    {
        protected readonly ApplicationDbContext Context;
        public BaseRepository(ApplicationDbContext context)
        {
            Context = context;
        }

        public virtual async Task<TEntity?> GetAsync(Guid id)
        {
            return await Context.Set<TEntity>().FirstOrDefaultAsync(t => t.Id.Equals(id)); ;
        }
        public async Task<TEntity?> GetTracking(Guid id)
        {
            return await Context.Set<TEntity>().AsTracking().FirstOrDefaultAsync(t => t.Id.Equals(id));
        }
        public async Task AddAsync(TEntity entity)
        {
            await Context.Set<TEntity>().AddAsync(entity);
        }

        void IBaseRepository<TEntity>.Add(TEntity entity)
        {
            Context.Set<TEntity>().Add(entity);
        }

        public async Task AddRange(ICollection<TEntity> entities)
        {
            await Context.Set<TEntity>().AddRangeAsync(entities);
        }
        public void Update(TEntity entity)
        {
            Context.Update(entity);
        }
        public async Task<int> Save()
        {
            var result = await Context.SaveChangesAsync();
            return result;
        }
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await Context.Set<TEntity>().AnyAsync(expression);
        }
        public bool Exists(Expression<Func<TEntity, bool>> expression)
        {
            return Context.Set<TEntity>().Any(expression);
        }

        public TEntity? Get(Guid id)
        {
            return Context.Set<TEntity>().FirstOrDefault(t => t.Id.Equals(id)); ;
        }
    }
}
