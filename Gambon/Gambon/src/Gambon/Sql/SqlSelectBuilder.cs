using Gambon.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gambon.Sql
{
    public class SqlSelectBuilder<T> : SqlBaseBuilder where T : class
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

            IEnumerable<string> GetSqlFieldsFrom(IEnumerable<string> tableFields)
            {
                if (fields.IsNull())
                {
                    return typeof(T)
                        .GetProperties()
                        .Where(a => a.CanRead)
                        .Select(b => b.Name);
                }
                return tableFields;
            }
        }

        private string BuildSql(string sqlFields, string tableName)
        {
            if (ThereIsNo(condition))
            {
                return "SELECT {0} FROM {1}s".FormatWith(sqlFields, tableName);
            }
            return BuildSqlWithCondition(condition, sqlFields, tableName);

            string BuildSqlWithCondition(dynamic condition, string fields, string name)
            {
                var sqlWhere = new SqlWhereBuilder(condition).Build();
                return String.Format("SELECT {0} FROM {1}s WHERE {2}", fields, name, sqlWhere);
            }
        }
    }
}
