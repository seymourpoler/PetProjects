using Gambon.Commands;
using Gambon.Sql;

namespace Gambon.Factories
{
    public class CommandFactory
    {
        public static ISelectCommand Select(string connectionString)
        {
            return new SelectCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }

        public static IInsertCommand Insert(string connectionString)
        {
            return new InsertCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }

        public static IUpdateCommand Update(string connectionString)
        {
            return new UpdateCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }

        public static IDeleteCommand Delete(string connectionString)
        {
            return new DeleteCommand(
                    sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(
                        connectionString: connectionString),
                    sqlBuilder: new SqlBuilder());
        }
    }
}
