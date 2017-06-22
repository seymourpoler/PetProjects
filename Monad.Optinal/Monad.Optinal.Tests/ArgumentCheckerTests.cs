using System;
using NUnit.Framework;
using FluentAssertions;

namespace Monad.Optinal.Tests
{
	[TestFixture]
	public class ArgumentCheckerTests
	{
		[Test]
		public void ThrowsArgumentNullExceptionWhenArgumentIsNull()
		{
			User user = null;
			Action action = () => ArgumentChecker.CheckNull (user);

			action.ShouldThrow<ArgumentNullException> ();
		}

		internal class User
		{
			
		}
	}
}

