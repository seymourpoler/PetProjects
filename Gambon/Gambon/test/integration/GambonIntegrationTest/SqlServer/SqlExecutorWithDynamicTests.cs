using Gambon.SqlServer;
using System;
using System.Collections.Generic;
using Xunit;

namespace Gambon.Test.Integration.SqlServer
{
    public class SqlExecutorWithDynamicTests : IDisposable
    {
        private AppConfiguration configuration;
        private SqlConnectionFactory sqlConnectionFactory;
        private SqlExecutorWithDynamic sqlExecutor;

        public SqlExecutorWithDynamicTests()
        {
            configuration = new AppConfiguration();
            sqlConnectionFactory = new SqlConnectionFactory(configuration);
            sqlExecutor = new SqlExecutorWithDynamic(sqlConnectionFactory);
            sqlExecutor.ExecuteNonQuery("DELETE FROM Users");
        }

        [Fact]
        public void ReturnsAllFromUsers()
        {
            var users = sqlExecutor.ExecuteReader("SELECT * FROM USERS");

            Assert.NotNull(users);
            Assert.IsAssignableFrom<IEnumerable<dynamic>>(users);
        }

        [Fact]
        public void ReturnsFirstOrDefaultFromUsers()
        {
            var result = sqlExecutor.ExecuteFirstOrDefault("SELECT * FROM USERS");

            Assert.Null(result);
        }

        [Fact]
        public void ReturnsIdentificatorFromInsertedUser()
        {
            const string sql = "INSERT INTO USERS (Email, FirstName, LastName, Age) VALUES ('pp@pp.es', 'John', 'Smith', 53)";

            var userId = sqlExecutor.ExecuteNonQuery(sql);

            Assert.IsType<int>(userId);
        }

        public void Dispose()
        {
            sqlExecutor.ExecuteNonQuery("DELETE FROM Users");
        }
    }
}
