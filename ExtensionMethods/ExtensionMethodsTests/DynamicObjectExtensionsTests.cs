using ExtensionMethods;
using Xunit;

namespace ExtensionMethodsTests
{
    public class DynamicObjectExtensionsTests
    {
        [Fact]
        public void ReturnsNullWhenIsNull()
        {
            dynamic entity = null;

            var result = DynamicConverter.To<User>(entity);

            result.ShouldBeNull();
        }
        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
