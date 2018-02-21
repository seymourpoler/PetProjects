using Gambon.Sql;
using System;
using Xunit;

namespace Gambon.Test.Unit.Sql
{
    public class SqlBuilderTests
    {
        private readonly SqlBuilder sqlBuilder;

        public SqlBuilderTests()
        {
            sqlBuilder = new SqlBuilder();
        }

        [Fact]
        public void ReturnsSqlSelectAllFields()
        {
            var result = sqlBuilder.Select<User>();

            Assert.Equal(
                expected: "SELECT Id, Name, Age, Email FROM Users",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlSelectSomeFields()
        {
            var result = sqlBuilder.Select<User>(new[] { "Id", "Email" });

            Assert.Equal(
                expected: "SELECT Id, Email FROM Users",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlSelectSomeFieldsAndCondition()
        {
            var result = sqlBuilder.Select<User>(
                fields: new[] { "Id", "Email" },
                condition: new { Age = 12, Name = "John" });

            Assert.Equal(
                expected: "SELECT Id, Email FROM Users WHERE Age = 12 AND Name = 'John'",
                actual: result);
        }

        [Fact]
        public void ReturnsStringEmptyWhenEntityForInsertingIsNull()
        {
            var result = sqlBuilder.Insert<User>(null);

            Assert.Equal(expected: String.Empty, actual: result);
        }

        [Fact]
        public void ReturnsSqlInsert()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = sqlBuilder.Insert(newUser);

            Assert.Equal(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es')",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlInsertWithWhere()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = sqlBuilder.Insert(entity: newUser, condition: new { Id = "identificator" });

            Assert.Equal(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es') WHERE Id = 'identificator'",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlInsertWithSomeConditions()
        {
            var newUser = new User { Id = Guid.NewGuid().ToString(), Name = "Name", Age = 12, Email = "a@a.es" };

            var result = sqlBuilder.Insert(entity: newUser, condition: new { Id = "identificator", Age = 12 });

            Assert.Equal(
                expected: "INSERT INTO Users (Name, Age, Email) VALUES ('Name', 12, 'a@a.es') WHERE Id = 'identificator' AND Age = 12",
                actual: result);
        }

        [Fact]
        public void ReturnsStringEmptyWhenEntityForUpdatingIsNull()
        {
            var result = sqlBuilder.Update<User>(entity: null);

            Assert.Equal(expected: String.Empty, actual: result);
        }

        [Fact]
        public void ReturnsSqlUpdate()
        {
            var user = new User { Id = "Identificator", Name = "Name", Age = 12, Email = "a@a.es" };

            var result = sqlBuilder.Update(entity: user);

            Assert.Equal(
                expected: "UPDATE Users SET Name = 'Name', SET Age = 12, SET Email = 'a@a.es' WHERE Id = 'Identificator'",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlUpdateWithSomeConditions()
        {
            var user = new User { Id = "Identificator", Name = "Name", Age = 12, Email = "a@a.es" };

            var result = sqlBuilder.Update(entity: user, condition: new { Id = "identificator", Age = 13 });

            Assert.Equal(
                expected: "UPDATE Users SET Name = 'Name', SET Age = 12, SET Email = 'a@a.es' WHERE Id = 'identificator' AND Age = 13",
                actual: result);
        }

        [Fact]
        public void ReturnsSqlDeleteAll()
        {
            var result = sqlBuilder.Delete<User>();

            Assert.Equal(expected: "DELETE FROM Users", actual: result);
        }

        [Fact]
        public void ReturnsSqlDeleteWithSomeConditions()
        {
            var user = new User { Id = "Identificator", Name = "Name", Age = 12, Email = "a@a.es" };

            var result = sqlBuilder.Delete<User>(condition: new { Id = "identificator", Age = 13 });

            Assert.Equal(
                expected: "DELETE FROM Users WHERE Id = 'identificator' AND Age = 13",
                actual: result);
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
