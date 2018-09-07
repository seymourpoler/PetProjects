using System;
using System.Data.SQLite;
using WiMi.Domain.Pages;

namespace WiMi.Repositories.SQLite
{
    public class ExistPageRepository : IExistPageRepository
    {
        readonly DataBaseConfiguration configuration;

        public ExistPageRepository(
            DataBaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public bool Exist(Guid id)
        {
            const int oneElement = 1; 
            var result = false;
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                var sql = $"SELECT COUNT(*) FROM Pages WHERE Id = '{id.ToString()}'";
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    var executionResult = command.ExecuteScalar();
                    result = Convert.ToInt32(executionResult) == oneElement; 
                }
                connection.Close();
            }
            return result;
        }
    }
}
