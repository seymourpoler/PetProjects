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
		public void ReturnsSomeFromFunction()
		{
			var monad = new None<string> ();
			const string name = "John";

			var result = monad.Bind (some: (x) => new User{ Name = x }, none: () => new User{ Name = name });

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (name);
		}

		[Test]
		public void ReturnsNoneFromFunction()
		{
			var monad = new None<string> ();

			var result = monad.Bind (some: (x) => new User{ Name = x }, none: () => {return default(User);});

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void ReturnsSomeFromNoneFunction()
		{
			var monad = new None<string> ();
			const string name = "John";
			const string anotherName = "Harris";

			var result = monad.Bind (some: () => new User{ Name = name}, none: () => new User{ Name = anotherName });

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (anotherName);
		}

		[Test]
		public void BindsWithFunctionWithoutParameters()
		{
			const string name = "Tom";
			var monad = new Some<string> (name);

			var result = monad.Bind<User> (some: (_) => new User{ Name = name}, none: () => new User{ Name = name});

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
		public void ReturnsSomeWithFunction()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind (() => {return name;});	

			result.Should().BeOfType<Some<string>>();
			result.Value.Should ().Be (name);
		}

		[Test]
		public void ReturnsSomeFromFunctionForNone()
		{
			const string name = "Tom";
			const string surName = "Harris";
			var monad = new None<string> ();

			var result = monad.Bind (some:() => {return name;}, none: () => {return surName;});	

			result.Should().BeOfType<Some<string>>();
			result.Value.Should ().Be (surName);
		}

		[Test]
		public void ReturnsSomeWithOtherType()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind (() => {return new User{Name = name};});	

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (name);
		}

		[Test]
		public void ReturnsNoneWithFunctionAndAction()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind (some:() => {return name;}, none:() => {Console.WriteLine("Hello");});	

			result.Should().BeOfType<None<string>>();
		}

		[Test]
		public void ReturnsSomeWithOtherTypeAndNoneWithAction()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind (() => {return new User{Name = name};}, none: () => {Console.WriteLine("Hello");});	

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void BindsNoneWithAction()
		{
			var monad = new None<string> ();
			const string name = "John";
			var value = String.Empty;

			var result = monad.Bind<string> (some: (x) => value = x, none: () => {value = name;});

			result.Should().BeOfType<None<string>>();
			value.Should ().Be (name);
		}

		[Test]
		public void BindsWithActionOnlyForSome()
		{
			var monad = new None<string> ();
			var value = String.Empty;

			var result = monad.Bind (action: (x) =>  {value = x;});

			result.Should().BeOfType<None<string>>();
		}

		[Test]
		public void BindOnlyWithActionsWithParameters()
		{
			const string name = "Paul";
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind<string> (some: (x) => value = "James" , none: () => {value = name;});

			result.Should().BeOfType<None<string>>();
			value.Should ().Be (name);
		}

		[Test]
		public void BindOnlyWithActions()
		{
			const string name = "Paul";
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind (some: null, none: () => {value = name;});

			value.Should ().Be (name);
			result.Should().BeOfType<None<User>> ();
		}

		[Test]
		public void BindsOnlyWithSome(){
			var monad = new None<string> ();

			var result = monad.Bind<User> (func:(name) => new User{ Name = name });

			result.Should ().BeOfType<None<User>> ();
		}

		[Test]
		public void ReturnsSomeFromActionAndFunction()
		{
			const string name = "Paul";
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind (some: (x) => {value = x.Name; }, none: () => {return new User{Name = name};});

			result.Should().BeOfType<Some<User>> ();
			result.Value.Name.Should ().Be (name);
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

		[Test]
		public void ValueOrFailure(){
			var monad = Optional.From<User>(null); 

			Action action = () => {var value = monad.ValueOrFailure;};

			action.ShouldThrow<ValueMissingException> ();
		}

		[Test]
		public void ValueOr ()
		{
			var name = "Jim";
			var monad = Optional.From<string>(null); 

			var result = monad.ValueOr(()=> name);

			result.Should().Be(name);
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
