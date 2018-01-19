using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class DynamicHasPropertyTests
    {
        [Fact]
        public void ReturnsFalseWhenDynamicIsNull()
        {
            var result = new Dynamic(null).HasProperty("Name");

            result.ShouldBeFalse();
        }
    }
}