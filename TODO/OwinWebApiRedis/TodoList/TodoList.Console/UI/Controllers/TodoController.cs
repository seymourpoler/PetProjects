using System;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TodoList.Console.UI.Models;
using TodoList.Console.UI.Mappers;
using TodoList.Console.Domain.Entities;
using TodoList.Console.Domain.Services;

namespace TodoList.Console.UI.Controllers
{
    public class TodoController : ApiController
    {
        private readonly ITaskMapper _taskMapper;
        private readonly ITasksService _tasksService;

        public TodoController(ITasksService tasksService, ITaskMapper taskMapper)
        {
            _tasksService = tasksService;
            _taskMapper = taskMapper;
        }

        public HttpResponseMessage Get()
        {
            try
            {
                var tasks = _tasksService.GetAll();
                var tasksModels = _taskMapper.ToModel(tasks);
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
                var taskModel = _taskMapper.ToModel(task);
                return Request.CreateResponse(HttpStatusCode.OK, taskModel);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex);
            }
        }

        public HttpResponseMessage Post(Task task)
        {
            try
            {
                var taskSaved = _tasksService.Save(task);
                var taskModel = _taskMapper.ToModel(taskSaved);
                return Request.CreateResponse(HttpStatusCode.OK, taskModel);
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
                var taskModel = _taskMapper.ToModel(taskUpdated);
                return Request.CreateResponse(HttpStatusCode.OK, taskModel);
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
