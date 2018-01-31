using NUnit.Framework;
using System;

namespace Gambon.Test.Unit
{
    [TestFixture]
    public class SqlBuilderTests
    {
        [Test]
        public void ReturnsSqlSelectAllFields()
        {
            var result = new SqlBuilder<User>().Select();

            Assert.AreEqual("SELECT Id, Name, Age, Email FROM Users", result);
        }

        [Test]
        public void ReturnsSqlSelectSomeFields()
        {
            var result = new SqlBuilder<User>().Select(new[] { "Id", "Email" });

            Assert.AreEqual("SELECT Id, Email FROM Users", result);
        }

        [Test]
        public void ReturnsStringEmptyWhenEntityIsNull()
        {
            var result = new SqlBuilder<User>().Insert(null);

            Assert.AreEqual(String.Empty, result);
        }

        [Test]
        public void ReturnsSqlInsert()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = new SqlBuilder<User>().Insert(newUser);

            Assert.AreEqual("INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es')", result);
        }

        [Test]
        public void ReturnsSqlInsertWithWhere()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = new SqlBuilder<User>().Insert(entity: newUser, condition: new { Id = "identificator" });

            Assert.AreEqual(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es') WHERE Id = 'identificator'",
                actual: result);
        }

        [Test]
        public void ReturnsSqlInsertWithSomeConditions()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = new SqlBuilder<User>().Insert(entity: newUser, condition: new { Id = "identificator", Age = 12 });

            Assert.AreEqual(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es') WHERE Id = 'identificator' AND Age = 12",
                actual: result);
        }

        [Test]
        public void ReturnsSqlDeleteAll()
        {
            var result = new SqlBuilder<User>().Delete();

            Assert.AreEqual("DELETE FROM Users", result);
        }

        public class User
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Email { get; set; }
        }
    }
}
