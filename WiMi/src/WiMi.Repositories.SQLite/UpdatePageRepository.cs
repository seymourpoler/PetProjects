using System.Data.SQLite;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Update;

namespace WiMi.Repositories.SQLite
{
    public class UpdatePageRepository : IUpdatePageRepository
    {
        readonly DataBaseConfiguration configuration;

        public UpdatePageRepository(DataBaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Update(Page page)
        {
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                var sql = $"UPDATE Pages SET Title = '{page.Title}', Body = '{page.Body}' WHERE Id = '{page.Id.ToString()}'";
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
