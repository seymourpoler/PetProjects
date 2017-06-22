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
		public void ThrowsArgumentNullExceptionWhenFunctionFromNoneIsNull()
		{
			var monad = new None<string> ();

			Action action = ()=>  monad.Bind<User> (some: (x) => new User{ Name = x }, none: null);

			action.ShouldThrow<ArgumentNullException> ();
		}

		[Test]
		public void ReturnsNoneFromFunction()
		{
			var monad = new None<string> ();

			var result = monad.Bind (some: (x) => new User{ Name = x }, none: () => {return default(User);});

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void ReturnsSomeFromNoneFunctionWithoutParameters()
		{
			var monad = new None<string> ();
			const string name = "John";
			const string anotherName = "Harris";

			var result = monad.Bind (some: () => new User{ Name = name}, none: () => new User{ Name = anotherName });

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should ().Be (anotherName);
		}

		[Test]
		public void ThrowsArgumentNullExceptionWhenSomeFromNoneFunctionWithoutParametersIsNull()
		{
			var monad = new None<string> ();
			const string name = "John";

			Action action = () => monad.Bind<User> (some: () => new User{ Name = name}, none: null);

			action.ShouldThrow<ArgumentNullException> ();
		}

		[Test]
		public void ReturnsNoneFromNoneFunctionWithoutParameters()
		{
			var monad = new None<string> ();
			const string name = "John";

			var result = monad.Bind (some: () => new User{ Name = name}, none: () => {return default(User);});

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void ReturnsSoneWithFunctionWithoutParameters()
		{
			const string name = "Tom";
			var monad = new Some<string> (name);

			var result = monad.Bind<User> (some: (_) => new User{ Name = name}, none: () => new User{ Name = name});

			result.Should().BeOfType<Some<User>>();
			result.Value.Name.Should().Be(name);
		}

		[Test]
		public void ThrowArgumentNullExceptionWhenSoneWithFunctionWithoutParametersIsNull()
		{
			const string name = "Tom";
			var monad = new Some<string> (name);

			Action action = () => monad.Bind<User> (some: (_) => new User{ Name = name}, none: null);

			action.ShouldThrow<ArgumentNullException> ();
		}

		[Test]
		public void ReturnsNoneWithFunctionWithoutParameters()
		{
			const string name = "Tom";
			var monad = new Some<string> (name);

			var result = monad.Bind<User> (some: (_) => {return default(User);}, none: () => new User{ Name = name});

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void ReturnsNoneWithFunctionOnlyForSome()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind<User> (function:(_) => new User{ Name = name});

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void ThrowArgumentNullExceptionWhenNoneWithFunctionOnlyForSomeIsNull()
		{
			var monad = new None<string> ();

			Action action = () => monad.Bind<User> (function: null);

			action.ShouldThrow<ArgumentNullException> ();
		}

		[Test]
		public void ReturnsNoneWhenFunctionOnlyForSomeReturnsDefault()
		{
			var monad = new None<string> ();

			var result = monad.Bind<User> (function:(_) => default(User));

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
		public void ThrowsArgumentNullExceptionWhenSomeWithFunctionIsNull()
		{
			var monad = new None<string> ();

			Action action = () => monad.Bind (null);	

			action.ShouldThrow<ArgumentNullException> ();
		}

		[Test]
		public void ReturnsNoneWithFunctionReturnsNull()
		{
			var monad = new None<string> ();

			var result = monad.Bind (() => {return null;});	

			result.Should().BeOfType<None<string>>();
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
		public void ReturnsNoneWhenFunctionForNoneReturnsNull()
		{
			const string name = "Tom";
			var monad = new None<string> ();

			var result = monad.Bind (some:() => {return name;}, none: () => {return null;});	

			result.Should().BeOfType<None<string>>();
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
		public void ReturnsNoneFromFunctionWithOtherTypeReturnsNull()
		{
			var monad = new None<string> ();

			var result = monad.Bind (() => {return default(User);});	

			result.Should().BeOfType<None<User>>();
		}

		[Test]
		public void ReturnsNoneWithFunctionForSomeAndActionForNone()
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
		public void ReturnsNoneWithActions()
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
			value.Should ().Be (String.Empty);
		}

		[Test]
		public void ReturnsNoneForActionsWithParameters()
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

			var result = monad.Bind (some: (x) => {value = x.Name;} , none: () => {value = name;});

			result.Should().BeOfType<None<User>> ();
			value.Should ().Be (name);
		}

		[Test]
		public void ReturnsNoneWithFunctionForSome(){
			var monad = new None<string> ();

			var result = monad.Bind<User> (function:(name) => new User{ Name = name });

			result.Should ().BeOfType<None<User>> ();
		}

		[Test]
		public void ReturnsNoneWithFunctionForSomeReturnsNull(){
			var monad = new None<string> ();

			var result = monad.Bind<User> (function:(name) => {return default(User);});

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
		public void ReturnsNoneFromActionForSomeAndFunctionFormNoneReturnsNull()
		{
			var monad = new None<User> ();
			var value = String.Empty;

			var result = monad.Bind (some: (x) => {value = x.Name; }, none: () => {return default(User);});

			result.Should().BeOfType<None<User>> ();
		}

		[Test]
		public void OrValue(){
			var monad = Optional.From<string>(null);

			var result = monad.Or ("Peter");

			result.Value.Should ().Be ("Peter");
		}

		[Test]
		public void ReturnsSomeWhenOrFunction()
		{
			var name = "Pepe";
			var monad = Optional.From<User>(null); 

			var result = monad.Or (() => new User{ Name = name });

			result.Should().BeOfType<Some<User>> ();
			result.Value.Name.Should ().Be (name);
		}

		[Test]
		public void ReturnsNoneWhenOrFunctionReturnsNull()
		{
			var monad = Optional.From<User>(null); 

			var result = monad.Or (() => {return default(User);});

			result.Should().BeOfType<None<User>> ();
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
