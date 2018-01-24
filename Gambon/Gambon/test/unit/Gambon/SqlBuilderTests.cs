using Gambon.SqlServer;
using System;
using NUnit.Framework;

namespace Gambon.Test.Unit
{
	[TestFixture]
	public class SqlBuilderTests
	{
		[Test]
		public void ReturnsSqlSelectAllFields()
		{
			var result = new SqlBuilder<User>().Select();
			
			Assert.AreEqual("SELECT Id, Name, Age, Email FROM Users", result);
		}

		[Test]
		public void ReturnsSqlSelectSomeFields()
		{
			var result = new SqlBuilder<User>().Select(new[]{"Id", "Email"});
			
			Assert.AreEqual("SELECT Id, Email FROM Users", result);
		}

		[Test]
		public void ReturnsSqlDeleteAll()
		{
			var result = new SqlBuilder<User>().Delete();
			
			Assert.AreEqual("DELETE FROM Users", result);
		}

		class User
		{
			public Guid Id{get; set;}
			public string Name{get;set;}
			public int Age{get;set;}
			public string Email{get; set;}
		}
	}
}
