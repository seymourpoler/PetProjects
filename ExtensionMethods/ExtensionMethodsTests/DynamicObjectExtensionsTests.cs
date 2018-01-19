using ExtensionMethods;
using Shouldly;
using Xunit;

namespace ExtensionMethodsTests
{
    public class DynamicObjectExtensionsTests
    {
        [Fact]
        public void ReturnsNullWhenIsNull()
        {
            var result = DynamicConverter.To<User>(null);

            result.ShouldBeNull();
        }
        
        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
