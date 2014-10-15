using System;
using System.Linq;
using TodoList.Console.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Tests
{
    [TestClass]
    public class TasksRepositoryTests
    {
        private TasksRepository _repository;

        [TestInitialize]
        public void SetUp()
        {
            _repository = new TasksRepository();
        }

        [TestCleanup]
        public void TearDown()
        {
            var data = _repository.GetAll();
            data.ToList().ForEach(task => { _repository.Delete(task.Id);});
        }

        [TestMethod]
        public void Tasksrepository_Save()
        {
            var expected = _repository.Save(new Task { Name = "Task One" });

            Assert.AreNotEqual(Guid.Empty, expected.Id);
            _repository.Delete(expected.Id);
        }

        [TestMethod]
        public void Tasksrepository_GetById()
        {
            var task = _repository.Save(new Task { Name = "Task One" });

            var taskExpected = _repository.GetById(task.Id);

            Assert.IsNotNull(taskExpected);
            Assert.AreEqual(task.Id, taskExpected.Id);
            Assert.AreEqual(task.Name, taskExpected.Name);

            _repository.Delete(task.Id);
        }

        [TestMethod]
        public void Tasksrepository_Update()
        {
            var task = _repository.Save(new Task { Name = "Task One" });

            var taskToBeUpdated = _repository.GetById(task.Id);

            taskToBeUpdated.Name = "Name Updated";

            _repository.Update(taskToBeUpdated);

            var taskExpected = _repository.GetById(taskToBeUpdated.Id);

            Assert.AreEqual(taskExpected.Id, taskToBeUpdated.Id);
            Assert.AreEqual(taskExpected.Name, taskToBeUpdated.Name);

            _repository.Delete(task.Id);
        }

        [TestMethod]
        public void Tasksrepository_Delete()
        {
            var expected = _repository.Save(new Task { Name = "Task One" });
            _repository.Delete(expected.Id);

            var taskRemoved = _repository.GetById(expected.Id);

            Assert.IsNull(taskRemoved);
        }

        [TestMethod]
        public void Tasksrepository_GetAll()
        {
            var expected = _repository.Save(new Task { Name = "Task One" });

            var tasksFound = _repository.GetAll();

            Assert.IsTrue(tasksFound.Count > 0);
            _repository.Delete(expected.Id);
        }
    }
}
