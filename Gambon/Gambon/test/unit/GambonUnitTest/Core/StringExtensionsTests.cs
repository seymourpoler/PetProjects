using Gambon.Core;
using Xunit;

namespace Gambon.Test.Unit.Core
{
    public class StringExtensionsTests
    {
        [Fact]
        public void ReturnsFormattedText()
        {
            var result = "test {0}".FormatWith("one");

            Assert.Equal("test one", result);
        }
    }
}
