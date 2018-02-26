using Gambon.Sql;

namespace Gambon.Commands
{
    public interface IInsertCommand
    {
        void Execute<T>(T entity, dynamic condition = null) where T : class;
    }

    public class InsertCommand : IInsertCommand
    {
        private readonly ISqlExecutorWithGeneric sqlExecutor;
        private readonly ISqlBuilder sqlBuilder;

        public InsertCommand(ISqlExecutorWithGeneric sqlExecutor, ISqlBuilder sqlBuilder)
        {
            this.sqlExecutor = sqlExecutor;
            this.sqlBuilder = sqlBuilder;
        }

        public void Execute<T>(T entity, dynamic condition = null) where T : class
        {
            var sql = sqlBuilder.Insert<T>(entity: entity, condition: condition);
            sqlExecutor.ExecuteNonQuery(sql);
        }
    }
}
