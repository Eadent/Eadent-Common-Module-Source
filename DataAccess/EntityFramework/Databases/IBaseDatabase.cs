using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Eadent.Common.DataAccess.EntityFramework.Databases
{
    public interface IBaseDatabase
    {
        DbContext Context { get; }

        IDbContextTransaction Transaction { get; }

        string DatabaseName { get; set; }

        string DatabaseSchema { get; set; }

        IDbContextTransaction BeginTransaction();

        void CommitTransaction();

        void RollbackTransaction();

        int ExecuteSqlRaw(string sql, IEnumerable<object> parameters);

        int ExecuteSqlInterpolated(FormattableString sql);

        int SaveChanges();

        // Async Methods.

        Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken = default);

        Task CommitTransactionAsync(CancellationToken cancellationToken = default);

        Task RollbackTransactionAsync(CancellationToken cancellationToken = default);

        Task<int> ExecuteSqlRawAsync(string sql, IEnumerable<object> parameters, CancellationToken cancellationToken = default);

        Task<int> ExecuteSqlInterpolatedAsync(FormattableString sql, CancellationToken cancellationToken = default);

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
