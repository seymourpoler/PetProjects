using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit
{
    public class DeleteCommandTests
    {
        private readonly Mock<ISqlExecutorWithGeneric> sqlExecutor;
        private readonly ISqlBuilder sqlBuilder;
        DeleteCommand command;

        public DeleteCommandTests()
        {
            sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            sqlBuilder = new SqlBuilder();
            command = new DeleteCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);
        }

        [Fact]
        public void DeleteAll()
        {
            command.Execute<User>();

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery("DELETE FROM Users"));
        }

        [Fact]
        public void DeleteWithCondition()
        {
            command.Execute<User>(condition: new { Age = 23, Email = "a@a.es" });

            sqlExecutor
                .Verify(x => x.ExecuteNonQuery(It.Is<string>(y => y.Contains("WHERE Age = 23 AND Email = 'a@a.es'"))));
        }

        public class User
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
        }
    }
}
