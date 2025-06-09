using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Data;
using System.Linq.Expressions;
using System.Reflection;
using WatchListMovies.Common.Domain;
using WatchListMovies.Common.Domain.Repository;
using WatchListMovies.Domain.MovieAgg;
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

        public async Task BulkInsertAsync(
        IEnumerable<TEntity> data,
        string tableName,
        string connectionString,
        Dictionary<string, string>? columnMappings = null)
        {
            var dataTable = ToDataTable(data);

            using var connection = new SqlConnection(connectionString);
            await connection.OpenAsync();

            using var bulkCopy = new SqlBulkCopy(connection)
            {
                DestinationTableName = tableName
            };

            // Add column mappings (if provided)
            foreach (DataColumn column in dataTable.Columns)
            {
                var sourceColumn = column.ColumnName;
                var destinationColumn = columnMappings != null && columnMappings.ContainsKey(sourceColumn)
                    ? columnMappings[sourceColumn]
                    : sourceColumn;

                bulkCopy.ColumnMappings.Add(sourceColumn, destinationColumn);
            }

            await bulkCopy.WriteToServerAsync(dataTable);
        }

        private DataTable ToDataTable(IEnumerable<TEntity> data)
        {
            var dataTable = new DataTable();
            var properties = typeof(TEntity).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in properties)
            {
                var type = Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType;
                dataTable.Columns.Add(prop.Name, type);
            }

            foreach (var item in data)
            {
                var values = properties.Select(p => p.GetValue(item) ?? DBNull.Value).ToArray();
                dataTable.Rows.Add(values);
            }

            return dataTable;
        }

    }

}
