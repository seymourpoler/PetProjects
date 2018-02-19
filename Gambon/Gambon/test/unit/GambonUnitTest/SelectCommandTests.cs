using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit
{
    public class SelectCommandTests
    {
        [Fact]
        public void SelectsAllFields()
        {
            var sqlBuilder = new SqlBuilder();
            var sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var selectCommand = new SelectCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);

            selectCommand.Execute<User>();

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains("FROM Users"))));
        }

        [Fact]
        public void SelectsSomeFields()
        {
            var sqlBuilder = new SqlBuilder();
            var sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var selectCommand = new SelectCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);

            selectCommand.Execute<User>(fields: new[] { "Id", "FirstName" });

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains(" Id, FirstName "))));
        }

        [Fact]
        public void SelectsWithCondition()
        {
            var sqlBuilder = new SqlBuilder();
            var sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var selectCommand = new SelectCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);

            selectCommand.Execute<User>(fields: new[] { "Id", "FirstName" }, condition: new { Age = 12 });

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains(" WHERE Age = 12"))));
        }

        public class User
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public int Age { get; set; }
        }
    }
}
