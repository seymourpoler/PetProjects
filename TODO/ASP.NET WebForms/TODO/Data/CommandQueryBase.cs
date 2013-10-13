using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq.Expressions;
using Infraestructure;

namespace Data
{
    public abstract class RepositoryBase
    {
        private string _connectionString = Configuracion.ConnectionString;

        protected RepositoryBase()
        {
        }

        public IEnumerable<TType> Query<TType>(string query, Func<IDataRecord, TType> parser, object parameters = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var command = BuildCommand(sqlConnection, query, parameters);
                var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    yield return parser(reader);
                }
                sqlConnection.Close();
            }
        }

        public void Execute(string sql, object parameters = null)
        {
            using (var sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                var command = BuildCommand(sqlConnection, sql, parameters);
                command.ExecuteNonQuery();
                sqlConnection.Close();
            }
        }

        protected virtual SqlCommand BuildCommand(SqlConnection connection, string sql, object parameters)
        {
            var command = connection.CreateCommand();
            command.CommandText = sql;
            foreach (var parameter in BuildParameters(parameters))
            {
                command.Parameters.Add(parameter);
            }
            return command;
        }

        protected virtual IEnumerable<SqlParameter> BuildParameters(object parameters)
        {
            foreach (PropertyDescriptor propertyDecriptor in TypeDescriptor.GetProperties(parameters))
            {
                var name = propertyDecriptor.Name.StartsWith("@")
                    ? propertyDecriptor.Name
                    : "@" + propertyDecriptor.Name;
                var value = propertyDecriptor.GetValue(parameters);
                yield return new SqlParameter(name, value ?? DBNull.Value);
            }
        }

        protected static TOut Parse<T, TOut>(IDataRecord record, Expression<Func<T, TOut>> expression)
        {
            var memberExpression = (MemberExpression)expression.Body;
            var name = memberExpression.Member.Name;

            return (TOut)record[name];
        }
    }
}
