
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace React.Asp.Net.Core.Repository.SqlServer
{
    public class SqlExecutor : ISqlExecutor
    {
        readonly RepositoryConfiguration _configuration;

        public SqlExecutor(RepositoryConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
        }

        public int ExecuteScalar(string sql)
        {
            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    var result = (int)command.ExecuteScalar();
                    connection.Close();
                    return result;
                }
            }
        }

        public T ExecuteSingleReader<T>(string sql, Func<SqlDataReader, T> mapper) where T : class
        {
            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    if (!reader.Read()) { return null; }
                    var resut = mapper(reader);
                    connection.Close();
                    return resut;
                }
            }
        }

        public IEnumerable<T> ExecuteReader<T>(string sql, Func<SqlDataReader, T> mapper) where T : class
        {
            var result = new List<T>();
            using (var connection = new SqlConnection(_configuration.ConnectionString))
            {
                using (var command = new SqlCommand(sql, connection))
                {
                    connection.Open();
                    var reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        result.Add(item: mapper(reader));
                    }
                    connection.Close();
                    return result;
                }
            }
        }
    }
}
