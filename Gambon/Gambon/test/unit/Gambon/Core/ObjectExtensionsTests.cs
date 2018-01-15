using Gambon.Core;
using NUnit.Framework;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;

namespace GambonUnitTest.Core
{
    [TestFixture]
	public class ObjectExtensionsTests
	{
		[Test]
		public void ReturnsNullWhenIsNull()
		{
			object thing = null;
			
			var result = this.ToDynamic();
			
			Assert.IsNull(thing);
		}

        [Test]
        public void ReturnsDynamicWhereIsNameValueCollection()
        {
            var values = new NameValueCollection();
            values.Add("keyOne", "valueOne");
            values.Add("keyTwo", "valueTwo");
            values.Add("keyThree", "valueThree");
            values.Add("keyFour", "valueFour");

            var result = values.ToDynamic();

            Assert.AreEqual("valueThree", result.keyThree);
        }

		[Test]
		public void ReturnsEmptyDynamicWhereDictionaryIsEmpty()
		{
			var values = new Dictionary<string, object>();

			var result = values.ToDynamic();

			Assert.IsNotNull(result);
		}

		[Test]
		public void ReturnsDynamicWhereIsDictionary()
		{
			var values = new Dictionary<string, object>();
			values.Add("keyOne", "valueOne");
			values.Add("keyTwo", "valueTwo");
			values.Add("keyThree", "valueThree");
			values.Add("keyFour", "valueFour");

			var result = values.ToDynamic();

			Assert.AreEqual("valueTwo", result.keyTwo);
		}

		[Test]
        public void ReturnsNullFromNullDictionary()
        {
            object thing = null;

            var result = thing.ToDictionary();

            Assert.IsNull(result);
        }

        [Test]
        public void ReturnsDictionaryFromDynamic(){
            var entity = new { keyOne = "valuOne", keyTwo = "valueTwo" };

            var result = entity.ToDictionary();

            Assert.AreEqual("valueTwo", result["keyTwo"]);
        }

		[Test]
		public void ReturnsDictionaryFromObject()
		{
            var id = Guid.NewGuid();
            var entity = new User{ Id = id, Name = "Name", Age = 2 };

			var result = entity.ToDictionary();

			Assert.AreEqual(id, result["Id"]);
		}

        private class User{
            public Guid Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
