using Moq;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.UI.Controllers;
using TodoList.Console.Domain.Services;
using System.Net;

namespace TodoList.Tests.UI.Controllers
{
    [TestClass]
    public class TodoControllerTests
    {
        TodoController _todoController;
        Mock<ITasksService> _tasksService;
        [TestInitialize]
        public void setUp()
        {
            _todoController = new TodoController(_tasksService.Object);
        }

        [TestMethod]
        public void TodoController_GetAll()
        {
            _tasksService.Setup(x => x.GetAll()).Throws(new Exception());

            var response = _todoController.Get();

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }
    }
}
