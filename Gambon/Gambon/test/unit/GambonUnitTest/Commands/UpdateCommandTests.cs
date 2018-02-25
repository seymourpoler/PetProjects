using Gambon.Commands;
using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit.Commands
{
    public class UpdateCommandTests
    {
        private readonly SqlBuilder sqlBuilder;
        private readonly Mock<ISqlExecutorWithGeneric> sqlExecutor;
        private readonly UpdateCommand command;

        public UpdateCommandTests()
        {
            sqlBuilder = new SqlBuilder();
            sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            command = new UpdateCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);
        }

        [Fact]
        public void UpdatesUser()
        {
            var user = new User { };

            command.Execute(user);

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("UPDATE Users"))));
        }

        [Fact]
        public void UpdatesUserWithCondition()
        {
            var user = new User { Id = "identificator" };

            command.Execute(entity: user, condition: new { Name = "James" });

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("WHERE Name = 'James'"))));
        }
    }
}
