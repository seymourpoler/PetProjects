using Moq;
using System;
using System.Collections.Generic;
using TodoList.Console.UI.Models;
using TodoList.Console.Domain.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Tests.Domain.Services
{
    [TestClass]
    public class TasksServiceTests
    {
        private Mock<ITasksRepository> _repository;
        private TasksService _tasksService;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new Mock<ITasksRepository>();
            _tasksService = new TasksService(_repository.Object);
        }

        [TestMethod]
        public void TasksService_GetAll()
        {
            _repository.Setup(x => x.GetAll()).Returns(new List<Task> { new Task { Id = Guid.NewGuid(), Name = "Task One" }, new Task { Id = Guid.NewGuid(), Name = "Task Two" } });
            var expected = _tasksService.GetAll();
            _repository.Verify(x => x.GetAll());
        }
    }
}
