using System.Collections.Generic;
using System.Data.SqlClient;

namespace Gambon.SqlServer
{
    public class SqlExecutorWithGeneric : ISqlExecutorWithGeneric
    {
        private readonly SqlConnectionFactory sqlConnectionFactory;

        public SqlExecutorWithGeneric(SqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public int ExecuteNonQuery(string sql)
        {
            using (var connection = sqlConnectionFactory.Create())
            {
                var command = new SqlCommand(cmdText: sql, connection: connection);
                return command.ExecuteNonQuery();
            }
        }

        public IEnumerable<T> ExecuteReader<T>(string sql) where T : class
        {
            using (var connection = sqlConnectionFactory.Create())
            {
                var command = new SqlCommand(cmdText: sql, connection: connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    yield return dataReader.To<T>();
                }
            }
        }
    }
}
