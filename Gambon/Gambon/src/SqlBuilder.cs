using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Gambon.Core;

namespace Gambon
{
	public class SqlBuilder<T> where T : class
	{
		public string Select(IEnumerable<string> fields=null)
		{
			var typeName = typeof(T).Name;
			var sqlFields = BuildSqlFields(fields);
			return "SELECT {0} FROM {1}s".FormatWith(sqlFields, typeName);
		}

		private string BuildSqlFields(IEnumerable<string> fields=null)
		{
			var sqlFields = GetSqlFieldsFrom(fields);
			return String.Join(", ", sqlFields);
		}

		private IEnumerable<string> GetSqlFieldsFrom(IEnumerable<string> fields)
		{
			if(fields.IsNull())
			{
				return typeof(T)
					.GetProperties()
					.Where(a => a.CanRead)
					.Select(b => b.Name);
			}
			return fields;
		}

		public string Insert(T entity, dynamic condition=null)
		{
			if(entity.IsNull())
			{
				return String.Empty;
			}
			var typeName = typeof(T).Name;
			var sqlFields = BuildSqlFieldsWithoutId();
			var sqlValues = BuildSqlValuesWithoutId(entity);
			if(condition == null)
			{
				return "INSERT INTO {0}s ({1}) VALUES ({2})".FormatWith(typeName, sqlFields, sqlValues);
			}
			var properties = condition.GetType().GetProperties();
			var values = new StringBuilder();
			foreach(var property in properties)
			{
				var propertyName = property.Name;
				var propertyValue = property.GetValue(condition, null);
				if(property.PropertyType  == typeof(string)) 
				{
					values.Append(String.Format("{0} = '{1}'", propertyName, propertyValue));
				}
				else
				{
					values.Append(String.Format("{0} = {1}", propertyName, propertyValue));
				}
			}
			var sqlWhere =  String.Join(" AND ", values);
			return String.Format("INSERT INTO {0}s ({1}) VALUES ({2}) WHERE {3}", typeName, sqlFields, sqlValues, sqlWhere);
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
		
		private static object BuildValue(T entity, PropertyInfo property)
		{
			if(property.PropertyType  == typeof(string)) 
			{
				return "'{0}'".FormatWith(property.GetValue(entity, null));
			}
			return property.GetValue(entity, null);
		}

		public static string BuildWhereSql(T entity, dynamic condition)
		{
			var properties = condition.GetType().GetProperties();
			var values = new StringBuilder();
			foreach(var property in properties)
			{
				values.Append(BuildCondition(condition, property));
			}
			return String.Join(" AND ", values);
		}

		private string BuildCondition(dynamic condition, PropertyInfo property)
		{
			var propertyName = property.Name;
			var propertyValue = property.GetValue(condition, null);
			if(property.PropertyType  == typeof(string)) 
			{
				return String.Format("{0} = '{1}'", propertyName, propertyValue);
			}
			return String.Format("{0} = {1}", propertyName, propertyValue);
		}

		public string Delete()
		{
			var typeName = typeof(T).Name;
			return "DELETE FROM {0}s".FormatWith(typeName);
		}
	}
}
