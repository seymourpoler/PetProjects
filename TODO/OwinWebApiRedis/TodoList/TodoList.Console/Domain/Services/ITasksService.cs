using System;
using System.Collections.Generic;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Domain.Services
{
    public interface ITasksService
    {
        IList<Task> GetAll();
        Task GetById(Guid id);
        Task Save(Task task);
        Task Update(Task task);
        void Delete(Guid id);
    }
}
