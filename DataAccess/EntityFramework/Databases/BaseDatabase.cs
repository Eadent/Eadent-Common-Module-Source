using Eadent.Common.DataAccess.Exceptions;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

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

        // Async Methods.

        public async Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Transaction != null)
                throw new DatabaseException("A Transaction has already been Begun.");

            Transaction = await Database.BeginTransactionAsync(cancellationToken);

            return Transaction;
        }

        public async Task CommitTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Transaction == null)
                throw new DatabaseException("A Transaction has not been Begun.");

            await SaveChangesAsync(cancellationToken);

            await Transaction.CommitAsync(cancellationToken);
            await Transaction.DisposeAsync();
            Transaction = null;
        }

        public async Task RollbackTransactionAsync(CancellationToken cancellationToken = default)
        {
            if (Transaction == null)
                throw new DatabaseException("A Transaction has not been Begun.");

            await Transaction.RollbackAsync(cancellationToken);
            await Transaction.DisposeAsync();
            Transaction = null;
        }

        public Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default)
        {
            return Database.ExecuteSqlRawAsync(sql, parameters, cancellationToken);
        }

        public Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql, CancellationToken cancellationToken = default)
        {
            return Database.ExecuteSqlInterpolatedAsync(sql, cancellationToken);
        }

        public new Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return base.SaveChangesAsync(cancellationToken);
        }
    }
}
