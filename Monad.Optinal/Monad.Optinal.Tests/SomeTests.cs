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

			var result = monad.Bind<string, User> (some: (name) => new User{ Name = name }, none: null);

			result.Should().BeOfType<Some<User>>();
		}

		[Test]
		public void BindsWithAction()
		{
			const string name = "John";
			var monad = new Some<string> (name);
			var value = String.Empty;

			var result = monad.Bind (some: (x) =>  value = x, none: () =>  value = name);

			result.Should().BeOfType<Some<string>>();
			value.Should ().Be (name);
		}

		[Test]
		public void BindOnlyWithActions()
		{
			const string name = "Paul";
			var monad = new User{ Name = name }.ToOptional<User> ();
			var value = String.Empty;

			var result = monad.Bind (some: (_) => value = name, none: null);

			value.Should ().Be (name);
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
