using Gambon.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

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
            var typeName = typeof(T).Name;
            var sqlFields = BuildSqlFieldsWithoutId();
            var sqlValues = BuildSqlValuesWithoutId(entity);
            if (condition == null)
            {
                return "INSERT INTO {0}s ({1}) VALUES ({2})".FormatWith(typeName, sqlFields, sqlValues);
            }
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
            var sqlWhere = String.Join(" AND ", values);
            return "INSERT INTO {0}s ({1}) VALUES ({2}) WHERE {3}".FormatWith(typeName, sqlFields, sqlValues, sqlWhere);
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

        private string BuildWhereSql(T entity, dynamic condition)
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
