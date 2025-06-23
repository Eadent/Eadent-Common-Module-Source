using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Eadent.Common.DataAccess.EntityFramework.Repositories
{
    public interface IBaseRepository<TEntity, in TEntityIdType>
    {
        void Create(TEntity entity);

        TEntity Get(TEntityIdType entityId);

        TEntity GetFirstOrDefault(Func<TEntity, bool> where);

        TEntity GetLastOrDefault<TOrderByKey>(Expression<Func<TEntity, bool>> where, Expression<Func<TEntity, TOrderByKey>> orderBy);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        int SaveChanges();

        // Async Methods.

        Task CreateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<TEntity> GetAsync(TEntityIdType entityId, CancellationToken cancellationToken = default);

        Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);

        Task<TEntity> GetLastOrDefaultAsync<TOrderByKey>(
            Expression<Func<TEntity, bool>> where,
            Expression<Func<TEntity, TOrderByKey>> orderBy,
            CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);

        Task<List<TEntity>> GetManyAsync(Expression<Func<TEntity, bool>> where, CancellationToken cancellationToken = default);

        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
