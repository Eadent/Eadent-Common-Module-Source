using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;

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
    }
}
