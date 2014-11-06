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
        private User _userOne, _userTwo;
        [TestInitialize]
        public void Initialize()
        {
            _usersRepository = new UsersRepository(new TasksRepository(new RedisClient()), new RedisClient());
            _userOne = new User{ Email = "emailOne@email.com", Name="userOne", PassWord="password", Tasks = new List<Task> { new Task{ Title = "TaskOne" }, new Task{ Title = "TaskTwo" } }};
            _userTwo = new User { Email = "emailTwo@email.com", Name = "userTwo", PassWord = "password" };
            _usersRepository.Save(_userOne);
            _usersRepository.Save(_userTwo);
        }

        [TestCleanup]
        public void CleanUp()
        {
            var allusers = _usersRepository.GetAll();
            foreach(var user in allusers)
            {
                _usersRepository.Delete(user.Id);
            }
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
            Assert.AreNotEqual(Guid.Empty, userExpected.Tasks[0].Id);
            Assert.AreEqual("title", userExpected.Tasks[0].Title);
            _usersRepository.Delete(userExpected.Id);
        }

        [TestMethod]
        public void UsersRepository_GetAll()
        {
            var allUsers = _usersRepository.GetAll();

            Assert.IsNotNull(allUsers);
            Assert.IsTrue(allUsers.Count > 0);
            Assert.IsTrue(allUsers[0].Tasks.Count > 0);
            Assert.AreNotEqual(Guid.Empty, allUsers[0].Tasks[0].Id);
        }
    }
}
