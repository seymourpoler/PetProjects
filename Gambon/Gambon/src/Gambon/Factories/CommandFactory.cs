using Gambon.Commands;
using Gambon.Sql;
using Gambon.SqlServer;

namespace Gambon.Factories
{
    public class CommandFactory
    {
        public static SelectCommand Select(string connectionString)
        {
            return new SelectCommand(
                    sqlExecutor: new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            connectionString: connectionString)),
                    sqlBuilder: new SqlBuilder());
        }

        public static InsertCommand Insert(string connectionString)
        {
            return new InsertCommand(
                    sqlExecutor: new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            connectionString: connectionString)),
                    sqlBuilder: new SqlBuilder());
        }

        public static UpdateCommand Update(string connectionString)
        {
            return new UpdateCommand(
                    sqlExecutor: new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            connectionString: connectionString)),
                    sqlBuilder: new SqlBuilder());
        }

        public static DeleteCommand Delete(string connectionString)
        {
            return new DeleteCommand(
                    sqlExecutor: new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            connectionString: connectionString)),
                    sqlBuilder: new SqlBuilder());
        }
    }
}
