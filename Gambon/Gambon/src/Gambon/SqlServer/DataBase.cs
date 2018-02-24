using Gambon.Commands;
using Gambon.Sql;
using System.Collections.Generic;

namespace Gambon.SqlServer
{
    public class DataBase
    {
        private readonly ISelectCommand selectCommand;

        private DataBase(
            ISelectCommand selectCommand)
        {
            this.selectCommand = selectCommand;
        }

        //TODO: move to Factory
        public static DataBase Create()
        {
            return new DataBase(
                selectCommand: new SelectCommand(
                    sqlExecutor: new SqlExecutorWithGeneric(
                        sqlConnectionFactory: new SqlConnectionFactory(
                            configuration: new AppConfiguration())),
                    sqlBuilder: new SqlBuilder()));
        }


        public IEnumerable<T> Select<T>(
            IEnumerable<string> fields = null,
            dynamic condition = null) where T : class
        {
            return selectCommand.Execute<T>(
                fields: fields,
                condition: condition);
        }
    }
}
