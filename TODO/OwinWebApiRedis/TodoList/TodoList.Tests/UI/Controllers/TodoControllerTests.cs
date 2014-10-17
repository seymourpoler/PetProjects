using System;
using System.Net;
using System.Linq;
using TodoList.Console;
using Microsoft.Owin.Testing;
using System.Collections.Generic;
using TodoList.Console.UI.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.Infrastructure.Data.Repositories;
using System.Net.Http;
using System.Text;

namespace TodoList.Tests.UI.Controllers
{
    [TestClass]
    public class TodoControllerTests
    {
        private TestServer _server;
        private TasksRepository _repository;
        private Task _taskOne, _taskTwo;

        [TestInitialize]
        public void Initialize()
        {
            _server = TestServer.Create<StartUp>();
            _repository = new TasksRepository();
            _taskOne = _repository.Save(new Task { Name = "TaskOne" });
            _taskTwo = _repository.Save(new Task { Name = "TaskTwo" });
        }

        [TestCleanup]
        public void CleanUp()
        {
            _repository.Delete(_taskOne.Id);
            _repository.Delete(_taskTwo.Id);
        }

        [TestMethod]
        public void TodoController_Get()
        {
            var response = _server.HttpClient.GetAsync("/todo").Result;
            var result = response.Content.ReadAsStringAsync().Result;

            var tasks = JsonHelper.JsonDeserialize<IList<Task>>(result);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.IsTrue(tasks.ToList().Count >= 2);
        }

        [TestMethod]
        public void TodoController_Get_by_id()
        {
            var response = _server.HttpClient.GetAsync(string.Format("/todo/{0}", _taskTwo.Id)).Result;
            var result = response.Content.ReadAsStringAsync().Result;

            var taskFound = JsonHelper.JsonDeserialize<Task>(result);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreEqual(taskFound.Id, _taskTwo.Id);
        }

        [TestMethod]
        public void TodoController_Post()
        {
            var jsonTask = JsonHelper.JsonSerialize<Task>(new Task { Name= "Task to Post"});

            var content = new System.Net.Http.StringContent(jsonTask, Encoding.UTF8, "application/json");
            var response = _server.HttpClient.PostAsync("/todo", content).Result;
            var result = response.Content.ReadAsStringAsync().Result;
            var taskFound = JsonHelper.JsonDeserialize<Task>(result);

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            Assert.AreNotEqual(Guid.Empty, taskFound.Id);

            _repository.Delete(taskFound.Id);
        }
    }
}
