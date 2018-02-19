using Gambon.Sql;
using System;

namespace Gambon
{
    public class DeleteCommand
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
            throw new NotImplementedException();
        }
    }
}
