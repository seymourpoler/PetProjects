using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

		public string Insert(T entity)
		{
			var typeName = typeof(T).Name;
			var sqlFields = GetSqlFieldsWithoutId();
			var sqlValues = GetSqlValuesWithoutId(entity);
			return "INSERT INTO {0}s ({1}) VALUES ({2})".FormatWith(typeName, sqlFields, sqlValues);
		}

		private string GetSqlFieldsWithoutId()
		{
			var fields = typeof(T)
				.GetProperties()
				.Where(a => a.CanRead)
				.Where(c => c.Name != "Id")
				.Select(c => c.Name);
			return String.Join(", ", fields);			
		}
		
		private string GetSqlValuesWithoutId(T entity)
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
			if(property.PropertyType  == typeof(string)) 
			{
				return "'{0}'".FormatWith(property.GetValue(entity, null));
			}
			return property.GetValue(entity, null);
		}
		
		public string Delete()
		{
			var typeName = typeof(T).Name;
			return "DELETE FROM {0}s".FormatWith(typeName);
		}
	}
}
