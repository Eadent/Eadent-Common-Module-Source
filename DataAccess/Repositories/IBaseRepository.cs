using System;
using System.Collections.Generic;

namespace Eadent.Common.DataAccess.Repositories
{
    public interface IBaseRepository<TEntity, in TEntityIdType>
    {
        void Create(TEntity entity);

        TEntity? Get(TEntityIdType entityId);

        TEntity? GetFirstOrDefault(Func<TEntity, bool> where);

        IEnumerable<TEntity> GetAll();

        IEnumerable<TEntity> GetMany(Func<TEntity, bool> where);

        void Update(TEntity entity);

        void Delete(TEntity entity);

        int SaveChanges();
    }
}
