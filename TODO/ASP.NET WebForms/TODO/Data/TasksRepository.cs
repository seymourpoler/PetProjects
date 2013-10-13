using System;
using System.Data;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.Linq;
using Entities;

namespace Data
{
    public class TasksRepository: RepositoryBase
    {
        public TasksRepository()
        {
        }

        public void SaveTask(Task newTask) 
        {
            const string sql = @"INSERT INTO [Tasks](Name) 
				                        VALUES(@Name)";
			Execute(sql, new { newTask.Name});
        }

        public IEnumerable<Task> GetAllTasks()
        {
			return Query("SELECT Id, Name FROM [Tasks] ORDER BY Id", ParseTask);
        }

		protected virtual Task ParseTask(IDataRecord dataRecord)
		{
			return new Task
			{
				Id = Parse<Task, int>(dataRecord, x => x.Id),
				Name = Parse<Task, string>(dataRecord, x => x.Name)
			};
		}

        public void RemoveTask(Task task)
        {
            const string sql = @"DELETE [Tasks] 
                                WHERE Id = @Id";
            Execute(sql, new { task.Id });
        }
    }
}
