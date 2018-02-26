using Gambon.Sql;

namespace Gambon.Commands
{
    public interface IUpdateCommand
    {
        void Execute<T>(T entity, dynamic condition = null) where T : class;
    }

    public class UpdateCommand : IUpdateCommand
    {
        private readonly SqlBuilder sqlBuilder;
        private readonly ISqlExecutorWithGeneric sqlExecutor;

        public UpdateCommand(
            SqlBuilder sqlBuilder,
            ISqlExecutorWithGeneric sqlExecutor)
        {
            this.sqlBuilder = sqlBuilder;
            this.sqlExecutor = sqlExecutor;
        }

        public void Execute<T>(T entity, dynamic condition = null) where T : class
        {
            var sql = sqlBuilder.Update<T>(
                entity: entity,
                condition: condition);

            sqlExecutor.ExecuteNonQuery(sql);
        }
    }
}
