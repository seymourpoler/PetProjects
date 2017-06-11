﻿using System;
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

			var result = monad.Bind (some: null, none: () => new User{ Name = name });

			result.Should().BeOfType<Some<User>>();
		}

		[Test]
		public void BindsWithFunctionWithoutParameters()
		{
			const string name = "Tom";
			var monad = new Some<string> (name);

			var result = monad.Bind<string, User> (some: (_) => new User{ Name = name}, none: () => new User{ Name = name});

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should().Be(name);
		}

		[Test]
		public void BindsFunctionOnlyForSome()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind<User> (func:(_) => new User{ Name = name});

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void BindsNoneWithAction()
		{
			var monad = new None<string> ();
			const string name = "John";
			var value = String.Empty;

			var result = monad.Bind<string> (some: (x) => value = x, none: () => value = name);

			result.Should().BeOfType<Some<string>>();
			value.Should ().Be (name);
		}

		[Test]
		public void BindOnlyWithActionsWithParameters()
		{
			const string name = "Paul";
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind<string> (some: (x) => value = "James" , none: () => value = name);

			result.Should().BeOfType<Some<string>>();
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
		public void BindsOnlyWithSome(){
			var monad = new None<string> ();

			var result = monad.Bind<User> (func:(name) => new User{ Name = name });

			result.Should ().BeOfType<None<User>> ();
		}

		[Test]
		public void OrValue(){
			var monad = Optional.From<string>(null);

			var result = monad.Or ("Peter");

			result.Value.Should ().Be ("Peter");
		}

		[Test]
		public void OrFunction()
		{
			var name = "Pepe";
			var monad = Optional.From<User>(null); 

			var result = monad.Or (() => new User{ Name = name });

			result.Value.Name.Should ().Be (name);
		}

		[Test]
		public void Where(){
			var monad = Optional.From<User>(null); 

			var result = monad.Where ((x) => x.Name == "Tom");

			result.Should ().BeOfType<None<User>> ();
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
