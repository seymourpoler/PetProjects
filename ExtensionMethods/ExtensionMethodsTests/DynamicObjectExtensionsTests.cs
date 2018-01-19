using System;
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

        [Fact]
        public void ReturnsEmptyEntityFromDynamicWhenHasNoTheSameProperties()
        {
            var entity = new {Id = Guid.NewGuid()};

            var result = DynamicConverter.To<User>(entity);
            
            result.Name.ShouldBeNullOrEmpty();
        }
        
        private class User
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
