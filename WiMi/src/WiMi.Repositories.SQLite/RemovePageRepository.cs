using System;
using WiMi.Domain.Pages.Remove;

namespace WiMi.Repositories.SQLite
{
    public class RemovePageRepository : IRemovePageRepository
    {
        readonly ISqlExecutor sqlExecutor;

        public RemovePageRepository(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public void Remove(Guid id)
        {
            var sql = $"DELETE FROM Pages WHERE Id = '{id.ToString()}'";
            sqlExecutor.ExecuteNonQuery(sql);
        }
    }
}
