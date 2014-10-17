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

        [TestMethod]
        public void TasksService_GetById()
        {
            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Task { Id = Guid.NewGuid(), Name = "Task One" });
            var expected = _tasksService.GetById(Guid.NewGuid());
            _repository.Verify(x => x.GetById(It.IsAny<Guid>()));
        }

        [TestMethod]
        public void TasksService_Save()
        {
            _repository.Setup(x => x.Save(It.IsAny<Task>())).Returns(new Task { Id = Guid.NewGuid(), Name = "Task One" });

            var taskSaved = _tasksService.Save(new Task {});

            _repository.Verify(x => x.Save(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TasksService_Update()
        {
            _repository.Setup(x => x.Update(It.IsAny<Task>())).Returns(new Task { Id = Guid.NewGuid(), Name = "Task One" });

            var taskSaved = _tasksService.Update(new Task {});

            _repository.Verify(x => x.Update(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TasksService_Delete()
        {
            _repository.Setup(x => x.Delete(It.IsAny<Guid>()));

            _tasksService.Delete(Guid.NewGuid());

            _repository.Verify(x => x.Delete(It.IsAny<Guid>()));
        }
    }
}
