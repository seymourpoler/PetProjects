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
            Action action = () => Check.IsNull<ArgumentNullException>(null);

            action.ShouldThrow<ArgumentNullException>();
        }

        [Fact]
        public void ThrowsArgumentNullExceptionWhenArgumentSatisfyTheCondition()
        {
            Action action = () => Check.If<ArgumentNullException>(() => string.IsNullOrWhiteSpace(string.Empty));

            action.ShouldThrow<ArgumentNullException>();
        }
        
        [Fact]
        public void ThrowsArgumentNullExceptionWithMessageWhenArgumentSatisfyTheCondition()
        {
            const string  aMessage = "simple exception message";

            Should.Throw<CustomException>(() =>
                Check.If<CustomException>(() => string.IsNullOrWhiteSpace(string.Empty), aMessage)
            ).Message.ShouldBe(aMessage);
        }

        private class CustomException : Exception
        {
            public CustomException(string message): base(message)
            {
            }
        }
    }
}