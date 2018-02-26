using Gambon.Commands;
using Gambon.Factories;
using System.Collections.Generic;

namespace Gambon.SqlServer
{
    public class DataBase
    {
        //TODO: refactor extract interface
        private readonly ISelectCommand selectCommand;
        private readonly InsertCommand insertCommand;
        private readonly DeleteCommand deleteCommand;
        private readonly UpdateCommand updateCommand;
        private readonly ISqlExecutorWithGeneric sqlExecutor;

        private DataBase(
            ISelectCommand selectCommand,
            InsertCommand insertCommand,
            DeleteCommand deleteCommand,
            UpdateCommand updateCommand,
            ISqlExecutorWithGeneric sqlExecutor)
        {
            this.selectCommand = selectCommand;
            this.insertCommand = insertCommand;
            this.deleteCommand = deleteCommand;
            this.updateCommand = updateCommand;
            this.sqlExecutor = sqlExecutor;
        }

        //TODO: move to Factory
        public static DataBase Create(string connectionString)
        {
            return new DataBase(
                selectCommand: CommandFactory.Select(connectionString),
                insertCommand: CommandFactory.Insert(connectionString),
                deleteCommand: CommandFactory.Delete(connectionString),
                updateCommand: CommandFactory.Update(connectionString),
                sqlExecutor: SqlExecutorFactory.SqlExecutorWithGeneric(connectionString));
        }

        public IEnumerable<T> Select<T>(
            IEnumerable<string> fields = null,
            dynamic condition = null) where T : class
        {
            return selectCommand.Execute<T>(
                fields: fields,
                condition: condition);
        }

        public void Insert<T>(
            T entity,
            dynamic condition = null) where T : class
        {
            insertCommand.Execute<T>(
                entity: entity,
                condition: condition);
        }

        public void Update<T>(
            T entity,
            dynamic condition = null) where T : class
        {
            updateCommand.Execute<T>(
                entity: entity,
                condition: condition);
        }

        public void Delete<T>(
            dynamic condition = null) where T : class
        {
            deleteCommand.Execute<T>(condition: condition);
        }

        public void Sql(string sql)
        {
            sqlExecutor.ExecuteNonQuery(sql);
        }
    }
}
