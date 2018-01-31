using System;
using System.Collections.Generic;
using System.Linq;
using Gambon.Core;

namespace Gambon
{
	public class SqlSelectBuilder<T> where T : class
	{
		private readonly IEnumerable<string> fields;
		
		public SqlSelectBuilder(IEnumerable<string> fields=null)
		{
			this.fields = fields;
		}
		
		public string ToSql()
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
	}
}
