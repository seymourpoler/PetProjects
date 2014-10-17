using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoList.Console.UI.Models;
using TodoList.Console.Domain.Services;

namespace TodoList.Console.UI.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITasksService _tasksService;
        public TodoController(ITasksService tasksService)
        {
            _tasksService = tasksService;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var tasks = _tasksService.GetAll();
                return Request.CreateResponse(HttpStatusCode.OK, tasks);
            }
            catch(Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Get(Guid id)
        {
            try
            {
                var task = _tasksService.GetById(id);
                return Request.CreateResponse(HttpStatusCode.OK, task);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Pot(Task task)
        {
            try
            {
                var taskSaved = _tasksService.Save(task);
                return Request.CreateResponse(HttpStatusCode.OK, taskSaved);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Put(Task task)
        {
            try
            {
                var taskUpdated = _tasksService.Update(task);
                return Request.CreateResponse(HttpStatusCode.OK, taskUpdated);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Delete(Guid id)
        {
            try
            {
                _tasksService.Delete(id);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }
    }
}
