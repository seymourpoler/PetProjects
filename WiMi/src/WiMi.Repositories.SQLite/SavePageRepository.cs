using System.Data.SQLite;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Create;

namespace WiMi.Repositories.SQLite
{
    public class SavePageRepository : ISavePageRepository
	{
        readonly DataBaseConfiguration configuration;

        public SavePageRepository(DataBaseConfiguration dataBaseConfiguration)
        {
            configuration = dataBaseConfiguration;
        }

        public void Save(Page page)
		{
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                string sql = $"INSERT INTO Pages (Id, Title, Body, CreationDate) VALUES ('{page.Id.ToString()}', '{page.Title}', '{page.Body}', '{page.CreationDate.ToString("yyyy-MM-dd HH:mm:ss")}')";
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
		}
	}
}
