using Gambon.Commands;
using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit.Commands
{
    public class InsertCommandTests
    {
        private readonly SqlBuilder sqlBuilder;
        private readonly Mock<ISqlExecutorWithGeneric> sqlExecutor;
        private readonly InsertCommand command;
        private readonly User user;

        public InsertCommandTests()
        {
            sqlBuilder = new SqlBuilder();
            sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            command = new InsertCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);
            user = new User { Id = "identificator", Age = 34, Name = "John" };
        }

        [Fact]
        public void InsertsUser()
        {
            command.Execute(entity: user);

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("INSERT INTO Users"))));
        }

        [Fact]
        public void InsertsUserWithCondition()
        {
            command.Execute(entity: user, condition: new { Email = "a@a.es", Age = 24 });

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("WHERE Email = 'a@a.es' AND Age = 24"))));
        }
    }
}
