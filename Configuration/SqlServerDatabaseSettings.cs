namespace Eadent.Common.Configuration
{
    public class SqlServerDatabaseSettings : DatabaseSettings
    {
        private string _connectionString;

        public string ConnectionString
        {
            get
            {
                if (string.IsNullOrWhiteSpace(_connectionString))
                {
                    _connectionString = $"Server={DatabaseServer};Database={DatabaseName};Application Name={ApplicationName};User Id={UserName};Password={Password};Encrypt=false;";
                }

                return _connectionString;
            }
        }
    }
}
