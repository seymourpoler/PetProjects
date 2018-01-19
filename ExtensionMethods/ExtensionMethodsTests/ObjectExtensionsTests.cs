using ExtensionMethods;
using Shouldly;
using System;
using Xunit;

namespace ExtensionMethodsTests
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ReturnsNullDynamicObjectWhenItNull()
        {
            User user = null;

            var result = user.ToDynamic();

            Assert.Equal(null, result);
        }

        [Fact]
        public void ReturnsDynamicObject()
        {
            const string name = "john";
            var user = new User { Id = Guid.NewGuid(), Name = name };

            var result = user.ToDynamic();

            Assert.Equal(name, result.Name);
        }

        [Fact]
        public void ReturnsTrueWhenIsNull()
        {
            User user = null;

            var result = user.IsNull();

            result.ShouldBeTrue();
        }

        [Fact]
        public void ReturnsTrueWhenIsNotNull()
        {
            User user = new User();

            var result = user.IsNotNull();

            result.ShouldBeTrue();
        }


        private class User
        {
            public Guid Id { get; set; }
            public string Name { get; set; }

            public int Age { get; set; }
        }
    }
}
