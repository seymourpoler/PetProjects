using FluentAssertions;
using NUnit.Framework;

namespace Monad.Optinal.Tests
{
    [TestFixture]
    public class OptionalExtensionsTests
    {
        [Test]
        public void ConvertsToSomeFromValue()
        {
            var some = "John".ToOptional();

            some.Should().BeOfType<Some<string>>();
        }

        [Test]
        public void ConvertsToNoneFromNull()
        {
            User user = default(User);
            var none = user.ToOptional();

            none.Should().BeOfType<None<string>>();
        }

        private class User { }
    }
}
