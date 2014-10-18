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
    public class TasksServiceTests
    {
        private Mock<ITasksRepository> _repository;
        private TasksService _tasksService;
        private Task _taskOne;
        private Task _taskTwo;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new Mock<ITasksRepository>();
            _tasksService = new TasksService(_repository.Object);
            _taskOne = new Task { Id = Guid.NewGuid(), Title = "Task One", Description = "Description One" };
            _taskTwo = new Task { Id = Guid.NewGuid(), Title = "Task Two", Description = "Description Two" };
        }

        [TestMethod]
        public void TasksService_GetAll()
        {
            _repository.Setup(x => x.GetAll()).Returns(new List<Task> { _taskOne, _taskTwo });
            var expected = _tasksService.GetAll();
            _repository.Verify(x => x.GetAll());
        }

        [TestMethod]
        public void TasksService_GetById()
        {
            _repository.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(_taskOne);
            var expected = _tasksService.GetById(Guid.NewGuid());
            _repository.Verify(x => x.GetById(It.IsAny<Guid>()));
        }

        [TestMethod]
        public void TasksService_Save()
        {
            _repository.Setup(x => x.Save(It.IsAny<Task>())).Returns(_taskOne);

            var taskSaved = _tasksService.Save(new Task {});

            _repository.Verify(x => x.Save(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TasksService_Update()
        {
            _repository.Setup(x => x.Update(It.IsAny<Task>())).Returns(_taskOne);

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
