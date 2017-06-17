using NUnit.Framework;
using FluentAssertions;
using System;
using System.Linq;
using System.Collections.Generic;

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

		[Test]
		public void SimpleHelloTokenizer()
		{
			var result = "Hello".ToOptional ()
				.Where (x => x.StartsWith ("Hello"))
				.Bind<List<string>> (y => y.Split(' ').ToList<string>());

			result.Should ().BeOfType<Some<List<string>>> ();
			result.Value.First().Should ().Be ("Hello");
			result.Value.Count.Should ().Be (1);
		}
	}
}
