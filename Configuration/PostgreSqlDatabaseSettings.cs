namespace Eadent.Common.Configuration
{
    public class PostgreSqlDatabaseSettings : DatabaseSettings
    {
        private string _connectionString;

        public int DatabasePort { get; set; }

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    _connectionString = $"Server={DatabaseServer};Port={DatabasePort};Database={DatabaseName};Application Name={ApplicationName};User Id={UserName};Password={Password};Pooling=true;";
                }

                return _connectionString;
            }
        }
    }
}
