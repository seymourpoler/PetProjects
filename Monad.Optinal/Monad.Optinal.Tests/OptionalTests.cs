using System;
using NUnit.Framework;
using FluentAssertions;

namespace Monad.Optinal.Tests
{
	[TestFixture]
	public class OptionalTests
	{
		[Test]
		public void ReturnsSomeWhenThereIsSomeValue()
		{
			var some = Optional.From ("Tome");

			some.Should ().BeOfType<Some<string>> ();
		}

		[Test]
		public void ReturnsNoneWhenThereIsNoneValue()
		{
			var some = Optional.From<string> (null);

			some.Should ().BeOfType<None<string>> ();
		}
	}
}

