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
		public void BindsNoneWithFunction()
		{
			var monad = new None<string> ();
			const string name = "John";

			var result = monad.Bind (some: null, none: (_) => new User{ Name = name });

			result.Should().BeOfType<Some<User>>();
		}

		[Test]
		public void BindsNoneWithAction()
		{
			var monad = new None<string> ();
			const string name = "John";
			var value = String.Empty;

			var result = monad.Bind (some: null, none: () =>  value = name);

			result.Should().BeOfType<None<string>>();
			value.Should ().Be (name);
		}

		[Test]
		public void BindOnlyWithActionsWithParameters()
		{
			const string name = "Paul";
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind (some: null, none: () => value = name);

			result.Should().BeOfType<None<User>>();
			value.Should ().Be (name);
		}

		[Test]
		public void BindOnlyWithActions()
		{
			const string name = "Paul";
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind (some: null, none: () => value = name);

			value.Should ().Be (name);
		}

		[Test]
		public void OrValue(){
			var monad = Optional.From<string>(null);

			var result = monad.Or ("Peter");

			result.Value.Should ().Be ("Peter");
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
