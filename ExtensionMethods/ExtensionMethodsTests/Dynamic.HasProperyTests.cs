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

        [Fact]
        public void ReturnsFalseWhenPropertyNameIsNull()
        {
            var entity = new { Name="John" };
            
            var result = new Dynamic(entity).HasProperty("Name");

            result.ShouldBeFalse();
        }
    }
}