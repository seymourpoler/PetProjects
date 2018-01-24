using Gambon.SqlServer;
using System;
using NUnit.Framework;

namespace GambonUnitTest
{
	[TestFixture]
	public class SqlBuilderTests
	{
		[Test]
		public void ReturnsStringEmptyWhenEnityIsNull()
		{
			var sqlBuilder = new SqlBuilder<object>(null);
			
			var result = sqlBuilder.Select();
			
			Assert.AreEqual(String.Empty, result);
		}
	}
}
