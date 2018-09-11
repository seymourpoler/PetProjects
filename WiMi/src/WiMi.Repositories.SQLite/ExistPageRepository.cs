using System;
using WiMi.Domain.Pages;

namespace WiMi.Repositories.SQLite
{
    public class ExistPageRepository : IExistPageRepository
    {
        readonly ISqlExecutor sqlExecutor;

        public ExistPageRepository(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public bool Exist(Guid id)
        {
            const int oneElement = 1; 
            var result = false;
            var sql = $"SELECT COUNT(*) FROM Pages WHERE Id = '{id.ToString()}'";
            var executionResult = sqlExecutor.ExecuteScalar(sql);
            result = Convert.ToInt32(executionResult) == oneElement;
            return result;
        }
    }
}
