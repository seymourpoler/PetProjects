using System;
using System.Collections.Generic;
using TodoList.Console.Domain.Entities;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Console.Domain.Services
{
    public class TasksService : ITasksService
    {
        private readonly ITasksRepository _tasksRepository;

        public TasksService(ITasksRepository tasksRepository)
        {
            _tasksRepository = tasksRepository;
        }

        public IList<Task> GetAll()
        {
            var tasks = _tasksRepository.GetAll();
            if(tasks == null)
            {
                return new List<Task>();
            }
            return tasks;
        }

        public Task GetById(Guid id)
        {
            var task = _tasksRepository.GetById(id);
            if(task == null)
            {
                return new Task();
            }
            return task;
        }

        public Task Save(Task task)
        {
            return _tasksRepository.Save(task);
        }

        public Task Update(Task task)
        {
            return _tasksRepository.Update(task);
        }

        public void Delete(Guid id)
        {
            _tasksRepository.Delete(id);
        }

        public bool IsValidTaskForUpdate(Task task)
        {
            return !string.IsNullOrWhiteSpace(task.Title) && 
                    task.Id != null && 
                    task.Id != Guid.Empty;
        }

        public bool IsValidTaskForInsert(Task task)
        {
            return !string.IsNullOrWhiteSpace(task.Title);
        }
    }
}
