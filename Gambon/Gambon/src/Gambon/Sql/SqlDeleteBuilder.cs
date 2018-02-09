using Gambon.Core;
using System;
using System.Collections.Generic;

namespace Gambon.Sql
{
    public class SqlDeleteBuilder<T> where T : class
    {
        private readonly dynamic condition;

        public SqlDeleteBuilder(dynamic condition)
        {
            this.condition = condition;
        }

        public string ToSql()
        {
            var typeName = typeof(T).Name;
            if (condition == null)
            {
                return "DELETE FROM {0}s".FormatWith(typeName);
            }
            return String.Format("DELETE FROM {0}s WHERE {1}", typeName, BuildWhereSql(condition));
        }

        private string BuildWhereSql(dynamic condition)
        {
            var properties = condition.GetType().GetProperties();
            var values = new List<string>();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(condition, null);
                if (property.PropertyType == typeof(string))
                {
                    values.Add(String.Format("{0} = '{1}'", propertyName, propertyValue));
                }
                else
                {
                    values.Add(String.Format("{0} = {1}", propertyName, propertyValue));
                }
            }
            return String.Join(" AND ", values);
        }
    }
}
