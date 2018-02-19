using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit
{
    public class SelectCommandTests
    {
        [Fact]
        public void ExecuteSelectCommandWithAllFields()
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
