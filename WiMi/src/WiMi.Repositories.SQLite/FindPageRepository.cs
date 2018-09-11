using System;
using System.Collections.Generic;
using WiMi.Domain.Pages;
using WiMi.Domain.Pages.Find;

namespace WiMi.Repositories.SQLite
{
    public class  FindPageRepository: IFindPageRepository
    {
        readonly ISqlExecutor sqlExecutor;

        public FindPageRepository(ISqlExecutor sqlExecutor)
        {
            this.sqlExecutor = sqlExecutor;
        }

        public IReadOnlyCollection<PageFindingResponse> Find()
        {
            const string sql = "SELECT Id, Title FROM Pages";
            var result = sqlExecutor.ExecuteReader<PageFindingResponse>(sql, (reader) => {
                return new PageFindingResponse
                {
                    Id = Convert.ToString(reader["Id"]),
                    Title = Convert.ToString(reader["Title"])
                };
            });
            return result;
        }

        public Page FindBy(Guid id)
        {
            var sql = $"SELECT Id, Title, Body, CreationDate FROM Pages WHERE id = '{id}'";
            var result = sqlExecutor.ExecuteSingleReader(sql, (reader) => {
                return new Page(new Page.PersistenceState(
                            id: new Guid(Convert.ToString(reader["Id"])),
                            title: Convert.ToString(reader["Title"]),
                            body: Convert.ToString(reader["Body"]),
                            creationDate: Convert.ToDateTime(reader["CreationDate"])));
            });
            return result;
        }
    }
}
