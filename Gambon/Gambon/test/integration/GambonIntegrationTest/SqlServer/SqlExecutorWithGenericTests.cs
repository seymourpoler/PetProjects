using Gambon.SqlServer;
using System.Collections.Generic;
using Xunit;


namespace Gambon.Test.Integration.SqlServer
{
    public class SqlExecutorWithGenericTests
    {
        private AppConfiguration configuration;
        private SqlConnectionFactory sqlConnectionFactory;
        private SqlExecutorWithGeneric sqlExecutor;

        public SqlExecutorWithGenericTests()
        {
            configuration = new AppConfiguration();
            sqlConnectionFactory = new SqlConnectionFactory(configuration);
            sqlExecutor = new SqlExecutorWithGeneric(sqlConnectionFactory);
        }

        [Fact]
        public void ReturnsAllFields()
        {
            var users = sqlExecutor.ExecuteReader<User>("SELECT * FROM USERS");

            Assert.NotNull(users);
            Assert.IsAssignableFrom<IEnumerable<User>>(users);
        }

        public class User
        {
            public string Id { get; set; }
            public string Email { get; set; }
            public int Age { get; set; }
        }
    }
}
