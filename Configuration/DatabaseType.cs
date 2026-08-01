using System;

namespace Eadent.Common.Configuration
{
    public class DatabaseType
    {
        public const string SqlServerName = "SQL Server";

        public const string PostgreSqlName = "PostgreSQL";

        public const int SqlServer = 0;

        public const int PostgreSql = 1;

        public static int GetDatabaseType(string databaseTypeName)
        {
            if (string.Equals(databaseTypeName, SqlServerName, StringComparison.OrdinalIgnoreCase))
            {
                return SqlServer;
            }
            else if (string.Equals(databaseTypeName, PostgreSqlName, StringComparison.OrdinalIgnoreCase))
            {
                return PostgreSql;
            }
            else
            {
                throw new ArgumentException($"Invalid Database Type Name: {databaseTypeName}");
            }
        }
    }
}
