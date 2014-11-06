using System;
using ServiceStack.Redis;
using TodoList.Console.Domain.Entities;

namespace TodoList.Console.Infrastructure.Data.Repositories
{
    public class UsersRepository : IUsersRepository
    {
        private RedisClient _redisClient;
        public UsersRepository(RedisClient redisClient)
        {
            _redisClient = redisClient;
        }

        public User Save(User user)
        {
            user.Id = Guid.NewGuid();
            return _redisClient.Store(user);
        }
    }
}
