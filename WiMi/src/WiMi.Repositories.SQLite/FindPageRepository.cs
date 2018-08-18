using System;
using System.Collections.Generic;
using System.Data.SQLite;
using WiMi.Domain.Pages.Find;

namespace WiMi.Repositories.SQLite
{
    public class  FindPageRepository: IFindPageRepository
    {
        readonly DataBaseConfiguration configuration;

        public FindPageRepository(DataBaseConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public IReadOnlyCollection<PageFindingResponse> Find()
        {
            var result = new List<PageFindingResponse>();
            using (var connection = new SQLiteConnection(configuration.ConnectionString))
            {
                connection.Open();
                string sql = $"SELECT Id, Title FROM Pages";
                using (var command = new SQLiteCommand(commandText: sql, connection: connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new PageFindingResponse {
                                Id = Convert.ToString(reader["Id"]),
                                Title = Convert.ToString(reader["Title"])});
                        }
                    }
                }
                connection.Close();
            }
            return result.AsReadOnly();
        }
    }
}
