using Gambon.Commands;
using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit.Commands
{
    public class UpdateCommandTests
    {
        private SqlBuilder sqlBuilder;
        private Mock<ISqlExecutorWithGeneric> sqlExecutor;

        [Fact]
        public void UpdatesUser()
        {
            sqlBuilder = new SqlBuilder();
            sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var user = new User { };
            var command = new UpdateCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);

            command.Execute(user);

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("UPDATE Users"))));
        }

        [Fact]
        public void UpdatesUserWithCondition()
        {
            sqlBuilder = new SqlBuilder();
            sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var user = new User { Id = "identificator" };
            var command = new UpdateCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);

            command.Execute(entity: user, condition: new { Name = "James" });

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("WHERE Name = 'James'"))));
        }
    }
}
