using System;
using System.Collections.Generic;
using System.Linq.Expressions;

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
    }
}
