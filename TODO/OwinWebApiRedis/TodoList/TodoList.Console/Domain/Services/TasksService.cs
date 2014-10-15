using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;
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
            return _tasksRepository.GetAll();
        }

        public Task GetById(Guid id)
        {
            return _tasksRepository.GetById(id);
        }
    }
}
