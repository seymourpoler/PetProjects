using System;
using System.Data.SQLite;
using WiMi.Domain.Pages.Remove;

namespace WiMi.Repositories.SQLite
{
    public class RemovePageRepository : IRemovePageRepository
    {
        readonly DataBaseConfiguration configuration;

        public RemovePageRepository(DataBaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public void Remove(Guid id)
        {
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                var sql = $"DELETE FROM Pages WHERE Id = '{id.ToString()}'";
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    command.ExecuteNonQuery();
                }
                connection.Close();
            }
        }
    }
}
