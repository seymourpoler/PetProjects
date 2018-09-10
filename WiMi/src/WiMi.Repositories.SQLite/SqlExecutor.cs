using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace WiMi.Repositories.SQLite
{
    public interface ISqlExecutor
    {
        void ExecuteNonQuery(string sql);
        int ExecuteScalar(string sql);
        T ExecuteSingleReader<T>(string sql, Func<SQLiteDataReader, T> mapper) where T : class;
        IReadOnlyCollection<T> ExecuteReader<T>(string sql, Func<SQLiteDataReader, T> mapper) where T : class;
    }

    public class SqlExecutor : ISqlExecutor
    {
        readonly DataBaseConfiguration configuration;

        public SqlExecutor(DataBaseConfiguration dataBaseConfiguration)
        {
            configuration = dataBaseConfiguration;
        }

        public void ExecuteNonQuery(string sql)
        {
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }

        public int ExecuteScalar(string sql)
        {
            var result = 0;
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    var executionResult = command.ExecuteScalar();
                    result = Convert.ToInt32(executionResult);
                }
                connection.Close();
            }
            return result;
        }

        public T ExecuteSingleReader<T>(string sql, Func<SQLiteDataReader, T> mapper) where T : class
        {
            T result;
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        reader.Read();
                        result = mapper(reader);
                    }
                }
                connection.Close();
            }
            return result;
        }

        public IReadOnlyCollection<T> ExecuteReader<T>(string sql, Func<SQLiteDataReader, T> mapper) where T : class
        {
            var result = new List<T>();
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(mapper(reader));
                        }
                    }
                }
                connection.Close();
            }
            return result.AsReadOnly();
        }
    }
}
