using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Update;

namespace WiMi.Repositories.SQLite
{
    public class UpdatePageRepository : IUpdatePageRepository
    {
        readonly ISqlExecutor sqlExecutor;

        public UpdatePageRepository(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public void Update(Page page)
        {
            var sql = $"UPDATE Pages SET Title = '{page.Title}', Body = '{page.Body}' WHERE Id = '{page.Id.ToString()}'";
            sqlExecutor.ExecuteNonQuery(sql);
        }
    }
}
