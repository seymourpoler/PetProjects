using System;
using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class CheckTests
    {
        [Fact]
        public void ThrowsArgumentNullExceptionWhenArgumentIsNull()
        {
            var action = () => Check.IsNull<ArgumentNullException>(null);

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void ThrowsExceptionWithMessageWhenArgumentIsNull()
        {
            const string aMessage = "simple exception message";

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
            const string aMessage = "simple exception message";

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
            const string aMessage = "simple exception message";
            
            var action = () => Check.IsEmpty<ArgumentException, int>(Array.Empty<int>(), aMessage);

            action.ShouldThrow<ArgumentException>();
        }

        private class CustomException : Exception
        {
            public CustomException(string message): base(message)
            {
            }
        }
    }
}