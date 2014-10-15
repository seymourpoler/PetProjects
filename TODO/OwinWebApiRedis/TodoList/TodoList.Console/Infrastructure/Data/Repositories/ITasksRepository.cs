using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public interface ITasksRepository
    {
        IList<Task> GetAll();
        Task GetById(Guid Id);
        Task Save(Task task);
        Task Update(Task task);
        void Delete(Guid id);
    }
}
