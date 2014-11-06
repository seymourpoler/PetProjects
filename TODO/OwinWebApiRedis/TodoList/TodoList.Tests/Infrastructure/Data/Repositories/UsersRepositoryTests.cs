using System;
using ServiceStack.Redis;
using System.Collections.Generic;
using TodoList.Console.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Tests.Infrastructure.Data.Repositories
{
    [TestClass]
    public class UsersRepositoryTests
    {
        private UsersRepository _usersRepository;
        [TestInitialize]
        public void Initialize()
        {
            _usersRepository = new UsersRepository(new RedisClient());
        }

        [TestMethod]
        public void UsersRepository_Save_simpleUser()
        {
            var simpleUser = new User{};
            var userExpected = _usersRepository.Save(simpleUser);

            Assert.IsNotNull(userExpected);
            Assert.AreNotEqual(Guid.Empty, userExpected.Id);
            _usersRepository.Delete(userExpected.Id);

        }

        [TestMethod]
        public void UsersRepository_Save_a_user_with_tasks()
        {
            var simpleUser = new User { Email = "email@email.com", Name = "name", PassWord = "password", Tasks = new List<Task> { new Task{ Title = "title" } } };
            var userExpected = _usersRepository.Save(simpleUser);

            Assert.IsNotNull(userExpected);
            Assert.AreNotEqual(Guid.Empty, userExpected.Id);
            Assert.AreEqual("email@email.com", userExpected.Email);
            Assert.IsTrue(userExpected.Tasks.Count > 0);
            Assert.AreEqual("Title", userExpected.Tasks[0].Title);
            _usersRepository.Delete(userExpected.Id);
        }
    }
}
