using Eadent.Common.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;

namespace Eadent.Common.DataAccess.EntityFramework.Databases
{
    public abstract class BaseDatabase : DbContext, IBaseDatabase
    {
        public DbContext Context => this;

        public IDbContextTransaction Transaction { get; private set; }

        public string DatabaseName { get; set; }

        public string DatabaseSchema { get; set; }

        protected BaseDatabase(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public IDbContextTransaction BeginTransaction()
        {
            if (Transaction != null)
                throw new DatabaseException("A Transaction has already been Begun.");

            Transaction = Database.BeginTransaction();

            return Transaction;
        }

        public void CommitTransaction()
        {
            if (Transaction == null)
                throw new DatabaseException("A Transaction has not been Begun.");

            SaveChanges();

            Transaction.Commit();
            Transaction.Dispose();
            Transaction = null;
        }

        public void RollbackTransaction()
        {
            if (Transaction == null)
                throw new DatabaseException("A Transaction has not been Begun.");

            Transaction.Rollback();
            Transaction.Dispose();
            Transaction = null;
        }

        public int ExecuteSqlRaw(string sql, IEnumerable<object> parameters)
        {
            return Database.ExecuteSqlRaw(sql, parameters);
        }

        public int ExecuteSqlInterpolated(FormattableString sql)
        {
            return Database.ExecuteSqlInterpolated(sql);
        }

        public new int SaveChanges()
        {
            return base.SaveChanges();
        }
    }
}
