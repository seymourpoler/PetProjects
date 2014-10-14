using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
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
    }
}
