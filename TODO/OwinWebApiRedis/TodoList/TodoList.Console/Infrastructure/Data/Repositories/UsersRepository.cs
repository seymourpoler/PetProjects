using System;
using System.Linq;
using ServiceStack.Redis;
using System.Collections.Generic;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private RedisClient _redisClient;
        private ITasksRepository _tasksRepository;
        public UsersRepository(ITasksRepository tasksRepository, RedisClient redisClient)
        {
            _redisClient = redisClient;
            _tasksRepository = tasksRepository;
        }

        public User Save(User user)
        {
            user.Id = Guid.NewGuid();
            user.Tasks.ToList().ForEach(task => {
                task.Id = Guid.NewGuid();
            });
            return _redisClient.Store(user);
        }

        public IList<User> GetAll()
        {
            return _redisClient.GetAll<User>();
        }
        public User GetById(Guid Id)
        {
            return _redisClient.GetById<User>(Id);
        }

        public User Update(User user)
        {
            return _redisClient.Store(user);
        }
        public void Delete(Guid id)
        {
            _redisClient.DeleteById<User>(id.ToString());
        }
    }
}
