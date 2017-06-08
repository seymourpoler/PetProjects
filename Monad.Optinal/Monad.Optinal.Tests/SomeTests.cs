using System;
using NUnit.Framework;
using FluentAssertions;

namespace Monad.Optinal.Tests
{
    [TestFixture]
    public class SomeTests
    {
        [Test]
        public void ReturnsSomeFromValue()
        {
            var some = Some<string>.From("Tom");

            some.Should().BeOfType<Some<string>>();
        }

        [Test]
        public void ThrowsArgumentNullExceptionWhenValueIsNull()
        {
            Action action = () => Some<string>.From(null);

            action.ShouldThrow<ArgumentNullException>();
        }

		[Test]
		public void BindsWithFunction()
		{
			var monad = new Some<string> ("Tom");

			var result = monad.Bind (some: (name) => new User{ Name = name }, none: null);

			result.Should().BeOfType<Some<User>>();
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
