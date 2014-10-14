using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        public Task Save(Task task)
        {
            throw new NotImplementedException("Save");
        }

        public IEnumerable<Task> GetAll()
        {
            return new List<Task> { 
                new Task{Name = "TaskOne"},
                new Task{Name = "TaskTwo"},
                new Task{Name = "TaskThree"},
                new Task{Name = "TaskFour"}
            };
        }
        public Task GetById(Guid Id) 
        {
            throw new NotImplementedException();
        }

        public Task Update(Task task) {
            throw new NotImplementedException();
        }
        public void Delete(Guid id) {
            throw new NotImplementedException();
        }
    }
}
