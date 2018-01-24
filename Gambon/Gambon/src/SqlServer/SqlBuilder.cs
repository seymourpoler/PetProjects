using System;
using System.Collections.Generic;
using System.Linq;

namespace Gambon.SqlServer
{
	public class SqlBuilder<T> where T : class
	{
		public string Select(){
			var typeName = typeof(T).Name;
			var fields = BuildSqlFields();
			return String.Format("SELECT {0} FROM {1}s", fields, typeName);
		}
		
		private IEnumerable<string> GetFieldsFrom()
		{
			return typeof(T)
				.GetProperties()
				.Where(b => b.CanRead)
				.Select(c => c.Name);
		}
		
		private string BuildSqlFields()
		{
			var fields = GetFieldsFrom();
			return String.Join(", ", fields);
		}
	}
}
