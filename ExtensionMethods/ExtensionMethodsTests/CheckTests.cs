using System;
using System.Collections.Generic;
using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class CheckTests
    {
        const string aMessage = "simple exception message";
        
        [Fact]
        public void ThrowsArgumentNullExceptionWhenArgumentIsNull()
        {
            var action = () => Check.IsNull<ArgumentNullException>(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void DoesNotThrowAnExceptionWhenArgumentIsNotNull()
        {
            var action = () => Check.IsNull<CustomException>(aMessage);

            action.ShouldNotThrow();
        }
        
        [Fact]
        public void ThrowsExceptionWithMessageWhenArgumentIsNull()
        {
            Should.Throw<CustomException>(() =>
                Check.IsNull<CustomException>(null, aMessage)
            ).Message.ShouldBe(aMessage);
        }
        
        [Fact]
        public void DoesNotThrowAnExceptionWithMessageWhenArgumentIsNotNull()
        {
            const string notNull = "not null";
            var action = () => Check.IsNull<CustomException>(notNull, aMessage);

            action.ShouldNotThrow();
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenConditionIsNull()
        {
            var action = () => Check.If<CustomException>(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void ThrowsArgumentNullExceptionWhenArgumentSatisfyTheCondition()
        {
            var action = () => Check.If<ArgumentNullException>(() => string.IsNullOrWhiteSpace(string.Empty));

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void DoesNotThrowAnExceptionWhenArgumentDoesNotSatisfyTheCondition()
        {
            const string anyString = "simple string of characters";
            
            var action = () => Check.If<ArgumentNullException>(() => string.IsNullOrWhiteSpace(anyString));

            action.ShouldNotThrow();
        }

        [Fact]
        public void ThrowsExceptionWithMessageWhenArgumentSatisfyTheCondition()
        {
            Should.Throw<CustomException>(() =>
                Check.If<CustomException>(() => string.IsNullOrWhiteSpace(string.Empty), aMessage)
            ).Message.ShouldBe(aMessage);
        }
        
        [Fact]
        public void DoesNotThrowAnExceptionWithMessageWhenArgumentDoesNotSatisfyTheCondition()
        {
            const string anyString = "simple string of characters";

            var action = () => Check.If<ArgumentNullException>(() => string.IsNullOrWhiteSpace(anyString), aMessage);

            action.ShouldNotThrow();
        }

        [Fact]
        public void ThrowsAnExceptionWhenArgumentIsAnEmptyArray()
        {
            var action = () => Check.IsEmpty<ArgumentException, string>(Array.Empty<string>());

            action.ShouldThrow<ArgumentException>();
        }
        
        [Fact]
        public void ThrowsArgumentNullExceptionWhenArgumentIsANullEmptyArray()
        {
            var action = () => Check.IsEmpty<CustomException, string>(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void ThrowsAnExceptionWithMessageWhenArgumentIsAnEmptyArray()
        {
            var action = () => Check.IsEmpty<ArgumentException, int>(Array.Empty<int>(), aMessage);

            action.ShouldThrow<ArgumentException>();
        }

        [Fact]
        public void ThrowsAnExceptionWhenArgumentIsANullArray()
        {
            var action = () => Check.IsNullOrEmpty<CustomException, double>(null);

            action.ShouldThrow<CustomException>();
        }
        
        [Fact]
        public void ThrowsAnExceptionWhenArgumentIsAnEmptyList()
        {
            var action = () => Check.IsNullOrEmpty<CustomException, double>(new List<double>());

            action.ShouldThrow<CustomException>();
        }
        
        [Fact]
        public void ThrowsAnExceptionWithMessageWhenArgumentIsANullArray()
        {
            Should.Throw<CustomException>(() =>
                Check.IsNullOrEmpty<CustomException, double>(null, aMessage)
            ).Message.ShouldBe(aMessage);
        }
        
        [Fact]
        public void ThrowsAnExceptionWithMessageWhenArgumentIsAnEmptyList()
        {
            Should.Throw<CustomException>(() =>
                Check.IsNullOrEmpty<CustomException, double>(new List<double>(), aMessage)
            ).Message.ShouldBe(aMessage);
        }
        
        private class CustomException : Exception
        {
            public CustomException(){}
            public CustomException(string message): base(message) { }
        }
    }
}