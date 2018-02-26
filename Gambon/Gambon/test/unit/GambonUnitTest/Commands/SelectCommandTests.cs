﻿using Gambon.Commands;
using Gambon.Sql;
using Moq;
using Xunit;

namespace Gambon.Test.Unit.Commands
{
    public class SelectCommandTests
    {
        private SqlBuilder sqlBuilder;
        private Mock<ISqlExecutorWithGeneric> sqlExecutor;
        private ISelectCommand command;

        public SelectCommandTests()
        {
            sqlBuilder = new SqlBuilder();
            sqlExecutor = new Mock<ISqlExecutorWithGeneric>();
            command = new SelectCommand(
                sqlBuilder: sqlBuilder,
                sqlExecutor: sqlExecutor.Object);
        }

        [Fact]
        public void SelectsAllFields()
        {
            command.Execute<User>();

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains("FROM Users"))));
        }

        [Fact]
        public void SelectsSomeFields()
        {
            command.Execute<User>(fields: new[] { "Id", "FirstName" });

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains(" Id, FirstName "))));
        }

        [Fact]
        public void SelectsWithCondition()
        {
            command.Execute<User>(fields: new[] { "Id", "FirstName" }, condition: new { Age = 12 });

            sqlExecutor
                .Verify(x => x.ExecuteReader<User>(It.Is<string>(y => y.Contains(" WHERE Age = 12"))));
        }
    }
}
