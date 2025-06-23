using Eadent.Common.DataAccess.EntityFramework.Databases;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Eadent.Common.DataAccess.EntityFramework.Repositories
{
    public class BaseRepository<TDatabase, TEntity, TEntityIdType> : IBaseRepository<TEntity, TEntityIdType>
        where TDatabase : IBaseDatabase
        where TEntity : class
    {
        protected TDatabase Database { get; }

        public BaseRepository(TDatabase database)
        {
            Database = database;
        }

        public void Create(TEntity entity)
        {
            Database.Context.Set<TEntity>().Add(entity);
        }

        public TEntity Get(TEntityIdType entityId)
        {
            return Database.Context.Set<TEntity>().Find(entityId);
        }

        public TEntity GetFirstOrDefault(Func<TEntity, bool> where)
        {
            return Database.Context.Set<TEntity>().FirstOrDefault(where);
        }

        public TEntity GetLastOrDefault<TOrderByKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderByKey>> orderBy)
        {
            return Database.Context.Set<TEntity>().Where(where).OrderByDescending(orderBy).FirstOrDefault();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return Database.Context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetMany(Func<TEntity, bool> where)
        {
            return Database.Context.Set<TEntity>().Where(where);
        }

        public void Update(TEntity entity)
        {
            Database.Context.Set<TEntity>().Update(entity);
        }

        public void Delete(TEntity entity)
        {
            Database.Context.Set<TEntity>().Remove(entity);
        }

        public int SaveChanges()
        {
            return Database.SaveChanges();
        }

        // Async Methods.

        public async Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            await Database.Context.Set<TEntity>().AddAsync(entity, cancellationToken);
        }

        public async Task<TEntity> GetAsync(TEntityIdType entityId, CancellationToken cancellationToken = default)
        {
            return await Database.Context.Set<TEntity>().FindAsync(new object[] { entityId }, cancellationToken);
        }

        public async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return await Database.Context.Set<TEntity>().FirstOrDefaultAsync(where, cancellationToken);
        }

        public async Task<TEntity> GetLastOrDefaultAsync<TOrderByKey>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderByKey>> orderBy,
            CancellationToken cancellationToken = default)
        {
            return await Database.Context.Set<TEntity>()
                .Where(where)
                .OrderByDescending(orderBy)
                .FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default)
        {
            return await Database.Context.Set<TEntity>().ToListAsync(cancellationToken);
        }

        public async Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default)
        {
            return await Database.Context.Set<TEntity>().Where(where).ToListAsync(cancellationToken);
        }

        public Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Update(entity);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default)
        {
            Delete(entity);
            return Task.CompletedTask;
        }

        public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await Database.SaveChangesAsync(cancellationToken);
        }
    }
}
