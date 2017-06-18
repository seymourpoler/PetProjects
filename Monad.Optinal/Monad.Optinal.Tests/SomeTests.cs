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

			var result = monad.Bind<User> (some: (name) => new User{ Name = name }, none: () => new User{ Name = "Henry" });

			result.Should().BeOfType<Some<User>>();
		}

		[Test]
		public void BindsFunctionOnlyForSome()
		{
			const string name = "Tom";
			var monad = new Some<string> ("Luke");

			var result = monad.Bind<User> (func:(_) => new User{ Name = name});

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should().Be(name);
		}

		[Test]
		public void BindsWithFunctionWithoutParameters()
		{
			const string name = "Tom";
			var monad = new Some<string> (name);

			var result = monad.Bind<User> (some: (x) => new User{ Name = x}, none: () => new User{ Name = name} );

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should().Be(name);
		}

		[Test]
		public void ReturnsSomeWithFunction()
		{
			const string name = "Tom";
			var monad = new Some<string> ("Jim");

			var result = monad.Bind (() => {return name;});	

			result.Should().BeOfType<Some<string>>();
			result.Value.Should ().Be (name);
		}

		[Test]
		public void ReturnsSomeFromNoneFunction()
		{
			var monad = new None<string> ();
			const string name = "John";
			const string anotherName = "Harris";

			var result = monad.Bind (some: () => new User{ Name = name}, none: () => new User{ Name = anotherName });

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (name);
		}

		[Test]
		public void ReturnsSomeFromFunctionForSome()
		{
			const string name = "Tom";
			const string surName = "Harris";
			var monad = new Some<string> ("Jim");

			var result = monad.Bind (some:() => {return name;}, none: () => {return surName;});	

			result.Should().BeOfType<Some<string>>();
			result.Value.Should ().Be (name);
		}

		[Test]
		public void ReturnsSomeWithOtherType()
		{
			const string name = "Tom";
			var monad = new Some<string> ("Jim");

			var result = monad.Bind (() => {return new User{Name = name};});	

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (name);
		}

		[Test]
		public void ReturnsNoneWithFunctionAndAction()
		{
			const string name = "Tom";
			var monad = new Some<string> ("Jim");

			var result = monad.Bind (some:() => {return name;}, none:() => {Console.WriteLine("Hello");});	

			result.Should().BeOfType<Some<string>>();
			result.Value.Should ().Be (name);
		}

		[Test]
		public void ReturnsSomeWithOtherTypeAndNoneWithAction()
		{
			const string name = "Tom";
			var monad = new Some<string> ("Jim");

			var result = monad.Bind (() => {return new User{Name = name};}, none: () => {Console.WriteLine("Hello");});	

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (name);
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
		public void BindsWithActionOnlyForSome()
		{
			const string name = "John";
			var monad = new Some<string> (name);
			var value = String.Empty;

			var result = monad.Bind (action: (x) =>  {value = x;});

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

		[Test]
		public void BindsOnlyWithSome(){
			var monad = new Some<string> ("Henry");

			var result = monad.Bind<User> (func:(name) => new User{ Name = name });

			result.Should ().BeOfType<Some<User>> ();
			result.Value.Name.Should ().Be ("Henry");
		}

		[Test]
		public void OrValue(){
			var monad = "Paul".ToOptional<string> ();

			var result = monad.Or ("Peter");

			result.Value.Should ().Be ("Paul");
		}

		[Test]
		public void OrFunction()
		{
			const string originalName = "Franc";
			const string name = "Pepe";
			var monad = Optional.From<User>(new User{Name= originalName}); 

			var result = monad.Or (() => new User{ Name = name });

			result.Value.Name.Should ().Be ("Franc");
		}

		[Test]
		public void ReturnsSomeWhereIsTrue(){
			var monad = new User{Name = "John"}.ToOptional(); 

			var result = monad.Where ((x) => x.Name.Contains("o"));

			result.Should ().BeOfType<Some<User>> ();
		}

		[Test]
		public void ReturnsNoneWhereIsTrue(){
			var monad = new User{Name = "John"}.ToOptional(); 

			var result = monad.Where ((x) => x.Name == "Tom");

			result.Should ().BeOfType<None<User>> ();
		}

		[Test]
		public void ValueOrFailure(){
			const string name = "John";
			var monad = new User{Name = name}.ToOptional(); 

			var result = monad.ValueOrFailure;

			result.Name.Should ().Be(name);
		}

		[Test]
		public void ValueOr ()
		{
			var name = "John";
			var monad = new User{Name = name}.ToOptional(); 

			var result = monad.ValueOr (() => new User{Name = "Tom"});

			result.Name.Should ().Be (name);
		}

		private class User{
			public string Name{ get; set;}
		}
    }
}
