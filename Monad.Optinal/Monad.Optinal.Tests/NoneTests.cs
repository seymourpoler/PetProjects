using System;
using NUnit.Framework;
using FluentAssertions;

namespace Monad.Optinal.Tests
{
    [TestFixture]
    public class NoneTests
    {
        [Test]
        public void ReturnsNoneFromValue()
        {
            var some = None<string>.From(null);

            some.Should().BeOfType<None<string>>();
        }

        [Test]
        public void ThrowsArgumentNullExceptionWhenHasValue()
        {
            Action action = () => None<string>.From("Tom");

            action.ShouldThrow<ArgumentNullException>();
        }

		[Test]
		public void Binds()
		{
			var monad = new None<string> ();
			var value = String.Empty;
			const string name = "John";
			var result = monad.Bind (some: null, none: (_) =>  new User{Name = name});

			result.Should().BeOfType<Some<User>>();
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
