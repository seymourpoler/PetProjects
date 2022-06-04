using System;
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
        public void ThrowsExceptionWithMessageWhenArgumentIsNull()
        {
            Should.Throw<CustomException>(() =>
                Check.IsNull<CustomException>(null, aMessage)
            ).Message.ShouldBe(aMessage);
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
        public void ThrowsExceptionWithMessageWhenArgumentSatisfyTheCondition()
        {
            Should.Throw<CustomException>(() =>
                Check.If<CustomException>(() => string.IsNullOrWhiteSpace(string.Empty), aMessage)
            ).Message.ShouldBe(aMessage);
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
        public void ThrowsAnExceptionWithMessageWhenArgumentIsANullArray()
        {
            Should.Throw<CustomException>(() =>
                Check.IsNullOrEmpty<CustomException, double>(null, aMessage)
            ).Message.ShouldBe(aMessage);
        }
        
        private class CustomException : Exception
        {
            public CustomException(){}
            public CustomException(string message): base(message) { }
        }
    }
}