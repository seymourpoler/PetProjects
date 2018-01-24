using System;
using System.Collections.Generic;
using System.Linq;
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
		
		private string BuildSqlFields(IEnumerable<string> fields)
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
	
		public string Delete()
		{
			var typeName = typeof(T).Name;
			return "DELETE FROM {0}s".FormatWith(typeName);
		}
	}
}
