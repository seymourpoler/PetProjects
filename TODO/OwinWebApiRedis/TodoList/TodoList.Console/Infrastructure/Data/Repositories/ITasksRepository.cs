using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    interface ITasksRepository
    {
        IEnumerable<Task> GetAll();
        Task GetById(Guid Id);
        Task Save(Task task);
        Task Update(Task task);
        void Delete(Guid id);
    }
}
