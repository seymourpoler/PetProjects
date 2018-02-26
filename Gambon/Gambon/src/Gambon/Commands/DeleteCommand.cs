using Gambon.Sql;

namespace Gambon.Commands
{
    public interface IDeleteCommand
    {
        void Execute<T>(dynamic condition = null) where T : class;
    }

    public class DeleteCommand : IDeleteCommand
    {
        private readonly ISqlExecutorWithGeneric sqlExecutor;
        private readonly ISqlBuilder sqlBuilder;

        public DeleteCommand(ISqlExecutorWithGeneric sqlExecutor, ISqlBuilder sqlBuilder)
        {
            this.sqlExecutor = sqlExecutor;
            this.sqlBuilder = sqlBuilder;
        }

        public void Execute<T>(dynamic condition = null) where T : class
        {
            var sql = sqlBuilder.Delete<T>(condition);
            sqlExecutor.ExecuteNonQuery(sql);
        }
    }
}
