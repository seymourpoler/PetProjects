using Moq;
using System;
using System.Collections.Generic;
using TodoList.Console.Domain.Entities;
using TodoList.Console.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Tests.Domain.Services
{
    [TestClass]
    public class UsersServiceTests
    {
        private IUsersService _userService;
        private Mock<IUsersRepository> _usersRepository;

        [TestInitialize]
        public void Initialize()
        {
            _usersRepository = new Mock<IUsersRepository>();
            _userService = new UsersService(_usersRepository.Object);
        }

        [TestMethod]
        public void UsersService_Login_with_valid_credentials()
        {
            _usersRepository.Setup(x => x.GetAll()).Returns(new List<User> { new User { Email = "email@email", PassWord = "PassWord" }, new User { Email = "emailOne@email", PassWord = "PassWord" }, new User { Email = "emailTwo@email", PassWord = "PassWord" } });

            var user = new User{ Email="email@email", PassWord = "PassWord"};
            var loginResult = _userService.Login(user);

            Assert.IsTrue(loginResult);
        }
    }
}
