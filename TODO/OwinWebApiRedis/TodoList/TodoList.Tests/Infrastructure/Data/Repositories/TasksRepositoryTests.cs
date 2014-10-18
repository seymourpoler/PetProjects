using System;
using System.Linq;
using TodoList.Console.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;

namespace TodoList.Tests.Infrastructure.Data.Repositories
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
            data.ToList().ForEach(task => { _repository.Delete(task.Id); });
        }

        [TestMethod]
        public void TasksRepository_Save()
        {
            var expected = _repository.Save(new Task { Title = "Task One" });

            Assert.AreNotEqual(Guid.Empty, expected.Id);
            _repository.Delete(expected.Id);
        }

        [TestMethod]
        public void TasksRepository_Update()
        {
            var task = new Task { Title = "Task One" };
            var taskSaved = _repository.Save(task);
            taskSaved.Title = "Name Updated";

            var taskUpdated = _repository.Update(taskSaved);
            Assert.AreEqual(taskUpdated.Id, taskSaved.Id);
            Assert.AreEqual(taskUpdated.Title, taskSaved.Title);
            _repository.Delete(task.Id);
        }

        [TestMethod]
        public void TasksRepository_Update_when_task_is_not_found()
        {
            var task = _repository.Update(new Task { Id = Guid.NewGuid(), Title = "New Task"});
            var taskUpdated = _repository.GetById(task.Id);

            Assert.AreEqual(task.Id, taskUpdated.Id);

            _repository.Delete(taskUpdated.Id);
        }

        [TestMethod]
        public void TasksRepository_GetById()
        {
            var task = _repository.Save(new Task { Title = "Task One", Description = "Description " });

            var taskExpected = _repository.GetById(task.Id);

            Assert.IsNotNull(taskExpected);
            Assert.AreEqual(task.Id, taskExpected.Id);
            Assert.AreEqual(task.Title, taskExpected.Title);
            Assert.AreEqual(task.Description, taskExpected.Description);

            _repository.Delete(task.Id);
        }

        [TestMethod]
        public void TasksRepository_GetById_Return_null_when_is_not_found()
        {
            var taskExpected = _repository.GetById(Guid.NewGuid());
            
            Assert.IsNull(taskExpected);
        }

        [TestMethod]
        public void TasksRepository_Delete()
        {
            var expected = _repository.Save(new Task { Title = "Task One" });
            _repository.Delete(expected.Id);

            var taskRemoved = _repository.GetById(expected.Id);

            Assert.IsNull(taskRemoved);
        }

        [TestMethod]
        public void TasksRepository_Delete_it_is_ok_when_task_is_not_found()
        {
            _repository.Delete(Guid.NewGuid());

            Assert.IsTrue(true);
        }

        [TestMethod]
        public void TasksRepository_GetAll()
        {
            var expected = _repository.Save(new Task { Title = "Task One" });

            var tasksFound = _repository.GetAll();

            Assert.IsTrue(tasksFound.Count > 0);
            _repository.Delete(expected.Id);
        }
    }
}
