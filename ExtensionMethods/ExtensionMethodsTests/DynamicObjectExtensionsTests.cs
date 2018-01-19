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
            var entity = new {Id = Guid.NewGuid(), Email = "John@mail.com"};

            var result = DynamicConverter.To<User>(entity);
            
            result.Name.ShouldBeNullOrEmpty();
        }

        [Fact]
        public void ReturnsEntityFromDynamic()
        {
            const string name = "John";
            var entity = new { Name = name, Age = 10 };
            
            var result = DynamicConverter.To<User>(entity);

            result.Name.ShouldBe(name);
        } 
        
        private class User
        {
            public User()
            {
                Name = String.Empty;
                Age = 0;

            }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
