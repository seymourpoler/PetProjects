using Gambon.SqlServer;

namespace Gambon.Factories
{
    public class SqlExecutorFactory
    {
        public static SqlExecutorWithGeneric SqlExecutorWithGeneric(string connectionString)
        {
            return new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            connectionString: connectionString));
        }
    }
}
