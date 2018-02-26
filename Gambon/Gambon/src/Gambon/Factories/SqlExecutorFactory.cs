using Gambon.SqlServer;

namespace Gambon.Factories
{
    public class SqlExecutorFactory
    {
        public static ISqlExecutorWithGeneric SqlExecutorWithGeneric(string connectionString)
        {
            return new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            connectionString: connectionString));
        }
    }
}
