using System;
using System.Data.SQLite;
using WiMi.Domain.Pages;

namespace WiMi.Repositories.SQLite
{
	public class PageRepository : IPageRepository
	{
        readonly DataBaseConfiguration configuration;

        public PageRepository(DataBaseConfiguration dataBaseConfiguration)
        {
            configuration = dataBaseConfiguration;
        }

        public void Save(Page page)
		{
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                string sql = $"INSER INTO Pages (Id, Title, Body, CreationDate) VALUES ({page.Id.ToString()}, {page.Title}, {page.Body}, {page.CreationDate.ToString("yyyy-MM-dd HH:mm:ss")})";
                using (var command = new SQLiteCommand(connection))
                {
                    //command.CommandText = "INSERT INTO Language(LangTitle) VALUES (@Lang)";
                    //command.Prepare();
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
		}
	}
}
