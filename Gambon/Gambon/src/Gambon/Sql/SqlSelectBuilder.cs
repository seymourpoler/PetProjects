using Gambon.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gambon.Sql
{
    public class SqlSelectBuilder<T> where T : class
    {
        private readonly IEnumerable<string> fields;
        private readonly dynamic condition;

        public SqlSelectBuilder(
            IEnumerable<string> fields = null,
            dynamic condition = null)
        {
            this.fields = fields;
            this.condition = condition;
        }

        public string ToSql()
        {
            var typeName = typeof(T).Name;
            var sqlFields = BuildSqlFields(fields);
            return BuildSql(tableName: typeName, sqlFields: sqlFields);
        }

        private string BuildSqlFields(IEnumerable<string> fields = null)
        {
            var sqlFields = GetSqlFieldsFrom(fields);
            return String.Join(", ", sqlFields);
        }

        private IEnumerable<string> GetSqlFieldsFrom(IEnumerable<string> fields)
        {
            if (fields.IsNull())
            {
                return typeof(T)
                    .GetProperties()
                    .Where(a => a.CanRead)
                    .Select(b => b.Name);
            }
            return fields;
        }

        private string BuildSql(string sqlFields, string tableName)
        {
            if (ThereIsNo(condition))
            {
                return "SELECT {0} FROM {1}s".FormatWith(sqlFields, tableName);
            }
            return BuildSqlWithCondition(
                condition: condition,
                sqlFields: sqlFields,
                tableName: tableName);
        }

        private bool ThereIsNo(dynamic condition)
        {
            return condition == null;
        }

        private string BuildSqlWithCondition(dynamic condition, string sqlFields, string tableName)
        {
            var sqlWhere = new SqlWhereBuilder(condition).Build();
            return String.Format("SELECT {0} FROM {1}s WHERE {2}", sqlFields, tableName, sqlWhere);
        }
    }
}
