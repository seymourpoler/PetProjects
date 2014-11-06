using System;
using ServiceStack.Redis;
using TodoList.Console.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Tests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class UsersRepositoryTests
    {
        [TestMethod]
        public void UsersRepository_Save_simpleUser()
        {
            var simpleUser = new User{};
            var usersRepository = new UsersRepository(new RedisClient());
            var userExpected = usersRepository.Save(simpleUser);

            Assert.IsNotNull(userExpected);
            Assert.AreNotEqual(Guid.Empty, userExpected.Id);
        }
    }
}
