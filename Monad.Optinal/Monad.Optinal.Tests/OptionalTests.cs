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
	}
}

