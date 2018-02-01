using System;
using Xunit;

namespace Gambon.Test.Unit
{
    public class SqlBuilderTests
    {
        [Fact]
        public void ReturnsSqlSelectAllFields()
        {
            var result = new SqlBuilder().Select<User>();

            Assert.Equal("SELECT Id, Name, Age, Email FROM Users", result);
        }

        [Fact]
        public void ReturnsSqlSelectSomeFields()
        {
            var result = new SqlBuilder().Select<User>(new[] { "Id", "Email" });

            Assert.Equal("SELECT Id, Email FROM Users", result);
        }

        [Fact]
        public void ReturnsStringEmptyWhenEntityForInsertingIsNull()
        {
            var result = new SqlBuilder().Insert<User>(null);

            Assert.Equal(String.Empty, result);
        }

        [Fact]
        public void ReturnsSqlInsert()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = new SqlBuilder().Insert(newUser);

            Assert.Equal("INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es')", result);
        }

        [Fact]
        public void ReturnsSqlInsertWithWhere()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = new SqlBuilder().Insert(entity: newUser, condition: new { Id = "identificator" });

            Assert.Equal(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es') WHERE Id = 'identificator'",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlInsertWithSomeConditions()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = new SqlBuilder().Insert(entity: newUser, condition: new { Id = "identificator", Age = 12 });

            Assert.Equal(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es') WHERE Id = 'identificator' AND Age = 12",
                actual: result);
        }

        [Fact]
        public void ReturnsStringEmptyWhenEntityForUpdatingIsNull()
        {
            var result = new SqlBuilder().Update<User>(entity: null);

            Assert.Equal(expected: String.Empty, actual: result);
        }

        [Fact]
        public void ReturnsSqlDeleteAll()
        {
            var result = new SqlBuilder().Delete<User>();

            Assert.Equal("DELETE FROM Users", result);
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
