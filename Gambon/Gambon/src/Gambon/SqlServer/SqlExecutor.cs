using Gambon.Core;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace Gambon.SqlServer
{
    public class SqlExecutor : ISqlExecutor
    {
        private readonly SqlConnectionFactory sqlConnectionFactory;

        public SqlExecutor(SqlConnectionFactory sqlConnectionFactory)
        {
            this.sqlConnectionFactory = sqlConnectionFactory;
        }

        public IEnumerable<dynamic> ExecuteReader(string sql)
        {
            using (var connection = sqlConnectionFactory.Create())
            {
                var command = new SqlCommand(sql, connection);
                var dataReader = command.ExecuteReader();
                while (dataReader.Read())
                {
                    yield return dataReader.ToDynamic();
                }
            }
        }

        public dynamic ExecuteFirstOrDefault(string sql)
        {
            return ExecuteReader(sql).FirstOrDefault();
        }

        public int ExecuteNonQuery(string sql)
        {
            using (var connection = sqlConnectionFactory.Create())
            {
                var command = new SqlCommand(sql, connection);
                return command.ExecuteNonQuery();
            }
        }

        public dynamic ExecuteScalar(string sql)
        {
            using (var connection = sqlConnectionFactory.Create())
            {
                return new SqlCommand(sql, connection)
                    .ExecuteScalar()
                    .ToDynamic();
            }
        }
    }
}
