using System.Collections.Generic;
using TodoList.Console.UI.Models;

namespace TodoList.Console.Domain.Services
{
    public interface ITasksService
    {
        IList<Task> GetAll();
    }
}
