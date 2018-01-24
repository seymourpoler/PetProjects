using Gambon.SqlServer;
using System;
using NUnit.Framework;

namespace Gambon.Unit.Test.SqlServer
{
	[TestFixture]
	public class SqlBuilderTests
	{
		[Test]
		public void ReturnsSqlSelectAllFields()
		{
			var sqlBuilder = new SqlBuilder<User>();
			
			var result = sqlBuilder.Select();
			
			Assert.AreEqual("SELECT Id, Name, Age FROM Users", result);
		}
		
		private class User
		{
			public Guid Id{get; set;}
			public string Name{get;set;}
			public int Age{get;set;}
		}
	}
}
