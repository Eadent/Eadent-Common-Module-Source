using Eadent.Common.DataAccess.EntityFramework.Databases;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public TEntity? Get(TEntityIdType entityId)
        {
            return Database.Context.Set<TEntity>().Find(entityId);
        }

        public TEntity? GetFirstOrDefault(Func<TEntity, bool> where)
        {
            return Database.Context.Set<TEntity>().FirstOrDefault(where);
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
    }
}
