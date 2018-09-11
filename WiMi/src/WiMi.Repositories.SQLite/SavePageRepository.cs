using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Create;

namespace WiMi.Repositories.SQLite
{
    public class SavePageRepository : ISavePageRepository
	{
        readonly ISqlExecutor sqlExecutor;

        public SavePageRepository(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public void Save(Page page)
		{
            var sql = $"INSERT INTO Pages (Id, Title, Body, CreationDate) VALUES ('{page.Id.ToString()}', '{page.Title}', '{page.Body}', '{page.CreationDate.ToString("yyyy-MM-dd HH:mm:ss")}')";
            sqlExecutor.ExecuteNonQuery(sql);
		}
	}
}
