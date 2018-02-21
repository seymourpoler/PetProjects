using Gambon.Commands;
using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit.Commands
{
    public class InsertCommandTests
    {
        [Fact]
        public void InsertsUser()
        {
            var sqlBuilder = new SqlBuilder();
            var sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            var command = new InsertCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);
            var user = new User { };

            command.Execute(entity: user);

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("INSERT INTO Users"))));
        }
    }
}
