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
    }
}
