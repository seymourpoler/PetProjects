using Gambon.Core;
using System;

namespace Gambon.SqlServer
{
	public class SqlBuilder<T> where T : class
	{
		private readonly T entity;
		
		public SqlBuilder(T entity)
		{
			this.entity = entity;
		}
		
		public string Select(){
			
			if(entity.IsNull()){
				return String.Empty;
			}
			
			
			throw new NotImplementedException();
		}
	}
}
