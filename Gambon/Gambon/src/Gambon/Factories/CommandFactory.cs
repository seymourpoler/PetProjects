using Gambon.Commands;
using Gambon.Sql;

namespace Gambon.Factories
{
    public class CommandFactory
    {
        public static SelectCommand Select(string connectionString)
        {
            return new SelectCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }

        public static InsertCommand Insert(string connectionString)
        {
            return new InsertCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }

        public static UpdateCommand Update(string connectionString)
        {
            return new UpdateCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }

        public static DeleteCommand Delete(string connectionString)
        {
            return new DeleteCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }
    }
}
