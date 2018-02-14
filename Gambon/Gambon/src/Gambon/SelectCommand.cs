using Gambon.Sql;
using System.Collections.Generic;

namespace Gambon
{
    public class SelectCommand
    {
        private readonly ISqlExecutor sqlExecutor;
        private readonly ISqlBuilder sqlBuilder;

        public SelectCommand(ISqlExecutor sqlExecutor, ISqlBuilder sqlBuilder)
        {
            this.sqlExecutor = sqlExecutor;
            this.sqlBuilder = sqlBuilder;
        }

        public IReadOnlyCollection<T> Execute<T>(
            IEnumerable<string> fields = null,
            dynamic condition = null) where T : class
        {
            var sql = sqlBuilder.Select<T>(
                fields: fields,
                condition: condition);
            return sqlExecutor.ExecuteReader(sql);

        }
    }
}
