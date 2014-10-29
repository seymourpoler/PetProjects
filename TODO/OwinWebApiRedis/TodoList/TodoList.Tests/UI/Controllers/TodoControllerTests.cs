using Moq;
using System;
using System.Net;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.Hosting;
using System.Collections.Generic;
using TodoList.Console.UI.Mappers;
using TodoList.Console.UI.Controllers;
using TodoList.Console.Domain.Services;
using TodoList.Console.Domain.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TodoList.Console.UI.Models;

namespace TodoList.Tests.UI.Controllers
{
    [TestClass]
    public class TodoControllerTests
    {
        TodoController _todoController;
        Mock<ITasksService> _tasksService;
        Mock<ITaskMapper> _taskMapper;

        [TestInitialize]
        public void setUp()
        {
            _tasksService = new Mock<ITasksService>();
            _taskMapper = new Mock<ITaskMapper>();
            _todoController = new TodoController(_tasksService.Object, _taskMapper.Object);
            LoadRequestInController(_todoController);
        }

        protected void LoadRequestInController(ApiController controller)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, string.Empty);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = new HttpConfiguration(); ;
        }

        [TestMethod]
        public void TodoController_GetAll_return_Internal_Error()
        {
            _tasksService.Setup(x => x.GetAll()).Throws(new Exception());

            var response = _todoController.Get();

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TodoController_GetAll_Return_Ok()
        {
            _tasksService.Setup(x => x.GetAll()).Returns(new List<Task>());

            var response = _todoController.Get();

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            _tasksService.Verify(x => x.GetAll());
        }

        [TestMethod]
        public void TodoController_Get_return_Internal_Error()
        {
            _tasksService.Setup(x => x.GetById(It.IsAny<Guid>())).Throws(new Exception());

            var response = _todoController.Get(Guid.NewGuid());

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TodoController_Get_return_Ok()
        {
            _tasksService.Setup(x => x.GetById(It.IsAny<Guid>())).Returns(new Task());

            var response = _todoController.Get(Guid.NewGuid());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            _tasksService.Verify(x => x.GetById(It.IsAny<Guid>()));
        }

        [TestMethod]
        public void TodoController_Post_return_Internal_error()
        {
            _tasksService.Setup(x => x.IsValidTaskForInsert(It.IsAny<Task>())).Throws(new Exception());

            var response = _todoController.Post(new TaskModel());

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TodoController_Post_return_Ok()
        {
            _tasksService.Setup(x => x.IsValidTaskForInsert(It.IsAny<Task>())).Returns(true);
            _tasksService.Setup(x => x.Save(It.IsAny<Task>())).Returns(new Task());

            var response = _todoController.Post(new TaskModel());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            _tasksService.Verify(x => x.Save(It.IsAny<Task>()));
            _tasksService.Verify(x => x.IsValidTaskForInsert(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TodoController_Post_return_bad_request_with_bad_model()
        {
            _tasksService.Setup(x => x.IsValidTaskForInsert(It.IsAny<Task>())).Returns(false);

            var response = _todoController.Post(new TaskModel());

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            _tasksService.Verify(x => x.IsValidTaskForInsert(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TodoController_Put_return_Internal_error()
        {
            _tasksService.Setup(x => x.IsValidTaskForUpdate(It.IsAny<Task>())).Throws(new Exception());

            var response = _todoController.Put(new TaskModel());

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TodoController_Put_return_Ok()
        {
            _tasksService.Setup(x => x.IsValidTaskForUpdate(It.IsAny<Task>())).Returns(true);
            _tasksService.Setup(x => x.Update(It.IsAny<Task>())).Returns(new Task());

            var response = _todoController.Put(new TaskModel());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            _tasksService.Verify(x => x.Update(It.IsAny<Task>()));
            _tasksService.Verify(x => x.IsValidTaskForUpdate(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TodoController_Put_return_bad_request_with_bad_model()
        {
            _tasksService.Setup(x => x.IsValidTaskForUpdate(It.IsAny<Task>())).Returns(false);

            var response = _todoController.Put(new TaskModel());

            Assert.AreEqual(HttpStatusCode.BadRequest, response.StatusCode);
            _tasksService.Verify(x => x.IsValidTaskForUpdate(It.IsAny<Task>()));
        }

        [TestMethod]
        public void TodoController_Delete_return_Internal_error()
        {
            _tasksService.Setup(x => x.Delete(It.IsAny<Guid>())).Throws(new Exception());

            var response = _todoController.Delete(Guid.NewGuid());

            Assert.AreEqual(HttpStatusCode.InternalServerError, response.StatusCode);
        }

        [TestMethod]
        public void TodoController_Delete_return_Ok()
        {
            _tasksService.Setup(x => x.Delete(It.IsAny<Guid>()));

            var response = _todoController.Delete(Guid.NewGuid());

            Assert.AreEqual(HttpStatusCode.OK, response.StatusCode);
            _tasksService.Verify(x => x.Delete(It.IsAny<Guid>()));
        }
    }
}
