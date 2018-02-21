using Gambon.Commands;
using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit.Commands
{
    public class SelectCommandTests
    {
        private SqlBuilder sqlBuilder;
        private Mock<ISqlExecutorWithGeneric> sqlExecutor;
        private SelectCommand selectCommand;

        public SelectCommandTests()
        {
            sqlBuilder = new SqlBuilder();
            var sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var selectCommand = new SelectCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);
        }

        [Fact]
        public void SelectsAllFields()
        {
            selectCommand.Execute<User>();

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains("FROM Users"))));
        }

        [Fact]
        public void SelectsSomeFields()
        {
            selectCommand.Execute<User>(fields: new[] { "Id", "FirstName" });

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains(" Id, FirstName "))));
        }

        [Fact]
        public void SelectsWithCondition()
        {
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
