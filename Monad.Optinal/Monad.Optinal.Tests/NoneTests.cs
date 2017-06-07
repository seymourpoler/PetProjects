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

            some.Should().BeOfType<Some<string>>();
        }

        [Test]
        public void ThrowsArgumentNullExceptionWhenHasValue()
        {
            Action action = () => Some<string>.From("Tom");

            action.ShouldThrow<ArgumentNullException>();
        }
    }
}
