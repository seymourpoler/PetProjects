using System;
using NUnit.Framework;
using Gambon.Core;

namespace Gambon.Test.Unit.Core
{
	[TestFixture]
	public class StringExtensionsTests
	{
		[Test]
		public void ReturnsTrueWhenIsNull()
		{
			string text = null;
			
			var result = text.IsNullOrWhiteSpace();
			
			Assert.IsTrue(result);
		}

		[Test]
		public void ReturnsTrueWhenIsEmpty()
		{
			var text = String.Empty;
			
			var result = text.IsNullOrWhiteSpace();
			
			Assert.IsTrue(result);
		}
		
		[Test]
		public void ReturnsTrueWhenIsWhiteSpace()
		{
			var result = " ".IsNullOrWhiteSpace();
			
			Assert.IsTrue(result);
		}

		[Test]
		public void ReturnsFalseWhenHasValue()
		{
			var result = "text".IsNullOrWhiteSpace();
			
			Assert.IsFalse(result);
		}

		[Test]
		public void ReturnsStringEmptyWhenTextIsNull()
		{
			string text = null;
			
			var result = text.FormatWith(String.Empty);
			
			Assert.AreEqual(String.Empty, result);
		}

		[Test]
		public void ReturnsStringEmptyWhenTextIsEmpty()
		{
			var result = String.Empty.FormatWith("");
			
			Assert.AreEqual(String.Empty, result);
		}

		[Test]
		public void ReturnsStringEmptyWhenParametersAreNull()
		{
			var result = "text".FormatWith(null);
			
			Assert.AreEqual(String.Empty, result);
		}

		[Test]
		public void ReturnsFormattedTextWithParameters()
		{
			var result = "value: {0}".FormatWith("name");
			
			Assert.AreEqual("value: name", result);
		}	
	}
}
