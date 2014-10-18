using System.Collections.Generic;
using TodoList.Console.UI.Models;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.UI.Mappers
{
    public interface ITaskMapper
    {
        Task ToEntity(TaskModel model);
        TaskModel ToModel(Task entity);
        IList<TaskModel> ToModel(IList<Task> entity);
    }
}
