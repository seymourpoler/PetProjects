using System;
using ServiceStack.Redis;
using System.Collections.Generic;
using TodoList.Console.UI.Models;
using ServiceStack.Redis.Generic;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public class TasksRepository : ITasksRepository
    {
        private RedisClient _redisClient;

        public TasksRepository()
        {
            _redisClient = new RedisClient();
        }

        public Task Save(Task task)
        {
   
            task.Id = Guid.NewGuid();
            _redisClient.Store(task);
            return task;            
        }

        public IList<Task> GetAll()
        {
            return  _redisClient.GetAll<Task>();
        }
        public Task GetById(Guid Id) 
        {
            return _redisClient.GetById<Task>(Id);
        }

        public Task Update(Task task) 
        {  
            _redisClient.Store(task);
            return task;
        }
        public void Delete(Guid id) 
        {
            _redisClient.DeleteById<Task>(id.ToString());
        }
    }
}
