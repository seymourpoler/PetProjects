using System.Data.SqlClient;

namespace Gambon.SqlServer
{
    public class SqlConnectionFactory
    {
        private readonly Configuration configuration;

        public SqlConnectionFactory(Configuration configuration)
        {
            this.configuration = configuration;
        }

        public SqlConnection Create()
        {
            var connection = new SqlConnection(configuration.ConnectionString);
            connection.Open();
            return connection;
        }
    }
}
