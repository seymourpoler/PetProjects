
using System;
using NUnit.Framework;
using Gambon.Core;

namespace Gambon.Test.Unit.Core
{
	[TestFixture]
	public class StringExtensionsTests
	{
		[Test]
		public void ReturnsStringEmptyWhenTextIsNull()
		{
			string text = null;
			
			var result = text.FormatWith("");
			
			Assert.AreEqual(String.Empty, result);
		}

		[Test]
		public void ReturnsStringEmptyWhenTextIsEmpty()
		{
			string text = String.Empty;
			
			var result = text.FormatWith("");
			
			Assert.AreEqual(String.Empty, result);
		}


		[Test]
		public void ReturnsStringEmptyWhenParametersAreNull()
		{
			var text = "text";
			
			var result = text.FormatWith(null);
			
			Assert.AreEqual(String.Empty, result);
		}	
	}
}
