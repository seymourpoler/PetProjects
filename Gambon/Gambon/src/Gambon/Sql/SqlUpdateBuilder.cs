using Gambon.Core;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Gambon.Sql
{
    public class SqlUpdateBuilder<T> where T : class
    {
        private readonly T entity;
        private readonly dynamic condition;
        public SqlUpdateBuilder(T entity, dynamic condition)
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
            var properties = entity.GetType().GetProperties()
                .Where(a => a.CanRead)
                .Where(c => c.Name != "Id");
            var values = new List<string>();
            foreach (var property in properties)
            {
                var propertyName = property.Name;
                var propertyValue = property.GetValue(entity, null);
                if (property.PropertyType == typeof(string))
                {
                    values.Add(String.Format("SET {0} = '{1}'", propertyName, propertyValue));
                }
                else
                {
                    values.Add(String.Format("SET {0} = {1}", propertyName, propertyValue));
                }
            }
            var sqlUpdate = String.Join(", ", values);
            if (condition == null)
            {
                return "UPDATE {0}s {1} WHERE {2}".FormatWith(typeName, sqlUpdate, BuildWhereSql());
            }
            var sqlWhere = new SqlWhereBuilder(condition).Build();
            return String.Format("UPDATE {0}s {1} WHERE {2}", typeName, sqlUpdate, sqlWhere);
        }

        private string BuildWhereSql()
        {
            var property = entity.GetType().GetProperty("Id");
            var propertyName = property.Name;
            var propertyValue = property.GetValue(entity, null);
            if (property.PropertyType == typeof(string))
            {
                return "{0} = '{1}'".FormatWith(propertyName, propertyValue);
            }
            return "{0} = {1}".FormatWith(propertyName, propertyValue);
        }
    }
}
