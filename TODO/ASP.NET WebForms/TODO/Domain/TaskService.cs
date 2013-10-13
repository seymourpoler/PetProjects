using System;
using System.Collections.Generic;
using System.Linq;
using Entities;
using Data;

namespace Domain
{
    public class TaskService
    {
        private TasksRepository  _repository;

        public TaskService()
        {
            _repository = new TasksRepository();
        }

        public void AddNewTask(Task task)
        {
            _repository.SaveTask(task);
        }

        public IEnumerable<Task> GetAllTasks()
        {
            return _repository.GetAllTasks();
        }

        public void RemoveTask(Task task)
        {
            _repository.RemoveTask(task);
        }
    }
}
