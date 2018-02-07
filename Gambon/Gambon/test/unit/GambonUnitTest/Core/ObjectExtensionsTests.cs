using Gambon.Core;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using Xunit;

namespace Gambon.Test.Unit.Core
{
    public class ObjectExtensionsTests
    {
        [Fact]
        public void ReturnsNullWhenIsNull()
        {
            object thing = null;

            var result = this.ToDynamic();

            Assert.Null(thing);
        }

        [Fact]
        public void ReturnsDynamicWhereIsNameValueCollection()
        {
            var values = new NameValueCollection();
            values.Add("keyOne", "valueOne");
            values.Add("keyTwo", "valueTwo");
            values.Add("keyThree", "valueThree");
            values.Add("keyFour", "valueFour");

            var result = values.ToDynamic();

            Assert.Equal("valueThree", result.keyThree);
        }

        [Fact]
        public void ReturnsEmptyDynamicWhereDictionaryIsEmpty()
        {
            var values = new Dictionary<string, object>();

            var result = values.ToDynamic();

            Assert.NotNull(result);
        }

        [Fact]
        public void ReturnsDynamicWhereIsDictionary()
        {
            var values = new Dictionary<string, object>();
            values.Add("keyOne", "valueOne");
            values.Add("keyTwo", "valueTwo");
            values.Add("keyThree", "valueThree");
            values.Add("keyFour", "valueFour");

            var result = values.ToDynamic();

            Assert.Equal("valueTwo", result.keyTwo);
        }

        [Fact]
        public void ReturnsNullFromNullDictionary()
        {
            object thing = null;

            var result = thing.ToDictionary();

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsDictionaryFromDynamic()
        {
            var entity = new { keyOne = "valuOne", keyTwo = "valueTwo" };

            var result = entity.ToDictionary();

            Assert.Equal("valueTwo", result["keyTwo"]);
        }

        [Fact]
        public void ReturnsDictionaryFromObject()
        {
            var id = Guid.NewGuid();
            var entity = new User { Id = id, Name = "Name", Age = 2 };

            var result = entity.ToDictionary();

            Assert.Equal(id, result["Id"]);
        }

        private class User
        {
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
