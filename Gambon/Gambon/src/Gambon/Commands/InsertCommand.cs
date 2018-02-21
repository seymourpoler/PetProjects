using Gambon.Sql;

namespace Gambon.Commands
{
    public class InsertCommand
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
