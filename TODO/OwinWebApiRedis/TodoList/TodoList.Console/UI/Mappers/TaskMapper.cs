using System.Collections.Generic;
using TodoList.Console.UI.Models;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.UI.Mappers
{
    public class TaskMapper : ITaskMapper
    {
        public TaskMapper()
        {
            AutoMapper.Mapper.CreateMap<Task, TaskModel>();
            AutoMapper.Mapper.CreateMap<TaskModel, Task>();
        }

        public Task ToEntity(TaskModel model)
        {
            return AutoMapper.Mapper.Map<Task>(model);
        }

        public TaskModel ToModel(Task entity)
        {
            return AutoMapper.Mapper.Map<TaskModel>(entity);
        }

        public IList<TaskModel> ToModel(IList<Task> entity)
        {
            return AutoMapper.Mapper.Map<IList<TaskModel>>(entity);
        }
    }
}
