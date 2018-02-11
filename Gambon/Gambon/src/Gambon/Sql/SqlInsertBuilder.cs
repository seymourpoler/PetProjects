using Gambon.Core;
using System;
using System.Linq;
using System.Reflection;

namespace Gambon.Sql
{
    public class SqlInsertBuilder<T> where T : class
    {
        private readonly T entity;
        private readonly dynamic condition;

        public SqlInsertBuilder(T entity, dynamic condition)
        {
            this.entity = entity;
            this.condition = condition;
        }

        public string ToSql()
        {
            if (entity.IsNull())
            {
                return String.Empty;
            }
            return BuildSql(entity, condition);
        }

        private string BuildSql(T entity, dynamic condition)
        {
            var typeName = typeof(T).Name;
            var sqlFields = BuildSqlFieldsWithoutId();
            var sqlValues = BuildSqlValuesWithoutId(entity);
            if (ThereIsNo(condition))
            {
                return "INSERT INTO {0}s ({1}) VALUES ({2})".FormatWith(typeName, sqlFields, sqlValues);
            }
            return BuildSqlWithCondition(
                tableName: typeName,
                sqlFields: sqlFields,
                sqlValues: sqlValues);
        }

        private string BuildSqlFieldsWithoutId()
        {
            var fields = typeof(T)
                .GetProperties()
                .Where(a => a.CanRead)
                .Where(c => c.Name != "Id")
                .Select(c => c.Name);
            return String.Join(", ", fields);
        }

        private string BuildSqlValuesWithoutId(T entity)
        {
            var values = typeof(T)
                .GetProperties()
                .Where(a => a.CanRead)
                .Where(c => c.Name != "Id")
                .Select(b => BuildValue(entity, b));
            return String.Join(", ", values);
        }

        private object BuildValue(T entity, PropertyInfo property)
        {
            if (property.PropertyType == typeof(string))
            {
                return "'{0}'".FormatWith(property.GetValue(entity, null));
            }
            return property.GetValue(entity, null);
        }

        private bool ThereIsNo(dynamic condition)
        {
            return condition == null;
        }

        private string BuildSqlWithCondition(string tableName, string sqlFields, string sqlValues)
        {
            var sqlWhere = new SqlWhereBuilder(condition).Build();
            return "INSERT INTO {0}s ({1}) VALUES ({2}) WHERE {3}".FormatWith(tableName, sqlFields, sqlValues, sqlWhere);
        }
    }
}
