using Gambon.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Gambon.Sql
{
    public class SqlSelectBuilder<T> where T : class
    {
        private readonly IEnumerable<string> fields;
        private readonly dynamic condition;

        public SqlSelectBuilder(IEnumerable<string> fields = null, dynamic condition = null)
        {
            this.fields = fields;
            this.condition = condition;
        }

        public string ToSql()
        {
            var typeName = typeof(T).Name;
            var sqlFields = BuildSqlFields(fields);
            if (condition == null)
            {
                return "SELECT {0} FROM {1}s".FormatWith(sqlFields, typeName);
            }
            var sqlWhere = BuildSqlWhere();
            return "SELECT {0} FROM {1}s WHERE {2}".FormatWith(sqlFields, typeName, sqlWhere);
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

        private string BuildSqlWhere()
        {
            var properties = condition.GetType().GetProperties();
            var values = new StringBuilder();
            foreach (var property in properties)
            {
                values.Append(BuildCondition(condition, property));
            }
            return String.Join(" AND ", values);
        }

        private string BuildCondition(dynamic condition, PropertyInfo property)
        {
            var propertyName = property.Name;
            var propertyValue = property.GetValue(condition, null);
            if (property.PropertyType == typeof(string))
            {
                return String.Format("{0} = '{1}'", propertyName, propertyValue);
            }
            return String.Format("{0} = {1}", propertyName, propertyValue);
        }
    }
}
